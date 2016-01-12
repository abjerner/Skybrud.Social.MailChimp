using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.MailChimp.Endpoints.Raw;
using Skybrud.Social.MailChimp.Responses.Authentication;

namespace Skybrud.Social.MailChimp.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the MailChimp API as well as any OAuth 2.0 communication.
    /// </summary>
    public class MailChimpOAuthClient {

        #region Properties

        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the API endpoint to be used.
        /// </summary>
        public string ApiEndpoint { get; set; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public MailChimpUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public MailChimpOAuthClient() {
            Users = new MailChimpUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>clientId</code> and <code>clientSecret</code>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public MailChimpOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>clientId</code>, <code>clientSecret</code> and <code>redirectUri</code>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public MailChimpOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates the authorization URL using the specified <code>state</code>.
        /// </summary>
        /// <param name="state">The state to send to the MailChimp OAuth login page.</param>
        /// <returns>Returns an authorization URL based on <code>state</code>.</returns>
        public string GetAuthorizationUrl(string state) {
            return String.Format(
                "https://login.mailchimp.com/oauth2/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}",
                ClientId,
                RedirectUri,
                state
            );
        }

        /// <summary>
        /// Exchanges the specified authorization code for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the MailChimp OAuth dialog.</param>
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public MailChimpTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"grant_type", "authorization_code"},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri},
                {"code", authCode }
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://login.mailchimp.com/oauth2/token", null, query);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return MailChimpTokenResponse.ParseResponse(social);

        }

        /// <summary>
        /// Gets metadata about the authenticated MailChimp user.
        /// </summary>
        /// <returns>Returns an instance of <code>MailChimpMetadataResponse</code> representing the response.</returns>
        public MailChimpMetadataResponse GetMetadata()  {
        
            // Some validation
            if (String.IsNullOrWhiteSpace(AccessToken)) throw new PropertyNotSetException("AccessToken");

            // Make the call to the API
            SocialHttpResponse response = DoHttpGetRequest("https://login.mailchimp.com/oauth2/metadata");

            // Parse the response
            return MailChimpMetadataResponse.ParseResponse(response);

        }

        /// <summary>
        /// Makes a GET request to the MailChimp API. If the <code>AccessToken</code> property has been specified, the
        /// access token will added as an authorization header of the request.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the MailChimp API.</returns>
        public SocialHttpResponse DoHttpGetRequest(string url) {
            return DoHttpGetRequest(url, (SocialQueryString)null);
        }

        /// <summary>
        /// Makes a GET request to the MailChimp API. If the <code>AccessToken</code> property has been specified, the
        /// access token will added as an authorization header of the request.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the MailChimp API.</returns>
        public SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection query) {
            return DoHttpGetRequest(url, new SocialQueryString(query));
        }

        /// <summary>
        /// Makes a GET request to the MailChimp API. If the <code>AccessToken</code> property has been specified, the
        /// access token will added as an authorization header of the request.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the MailChimp API.</returns>
        public SocialHttpResponse DoHttpGetRequest(string url, IGetOptions options) {
            return DoHttpGetRequest(url, options == null ? null : options.GetQueryString());
        }

        /// <summary>
        /// Makes a GET request to the MailChimp API. If the <code>AccessToken</code> property has been specified, the
        /// access token will added as an authorization header of the request.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the MailChimp API.</returns>
        public SocialHttpResponse DoHttpGetRequest(string url, SocialQueryString query) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize a new instance of SocialQueryString if the one specified is NULL
            if (query == null) query = new SocialQueryString();

            if (!String.IsNullOrWhiteSpace(ApiKey) && !query.ContainsKey("apikey")) {
                query.Add("apikey", ApiKey);
            }

            // Append the query string to the URL
            if (!query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Append the API endpoint
            if (url.StartsWith("/")) {
                if (String.IsNullOrWhiteSpace(ApiEndpoint)) throw new PropertyNotSetException("ApiEndpoint");
                url = ApiEndpoint + url;
            }

            // Initialize a new HTTP request
            SocialHttpRequest request = new SocialHttpRequest {
                Url = url
            };

            // Add the authorization header if the "AccessToken" property is specified
            if (!String.IsNullOrWhiteSpace(AccessToken) && !query.ContainsKey("apikey")) {
                request.Authorization = "OAuth " + AccessToken;
            }

            // Get the HTTP response
            return request.GetResponse();

        }

        /// <summary>
        /// Makes a POST request to the MailChimp API. If the <code>AccessToken</code> property has been specified, the
        /// access token will added as an authorization header of the request.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the MailChimp API.</returns>
        public SocialHttpResponse DoHttpPostRequest(string url, IPostOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return DoHttpPostRequest(url, options.GetQueryString(), options.GetPostData(), options.IsMultipart);
        }

        /// <summary>
        /// Makes a POST request to the MailChimp API. If the <code>AccessToken</code> property has been specified, the
        /// access token will added as an authorization header of the request.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <param name="postData">The POST data.</param>
        /// <param name="isMultipart">If <code>true</code>, the content type of the request will be <code>multipart/form-data</code>, otherwise <code>application/x-www-form-urlencoded</code>.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the MailChimp API.</returns>
        public SocialHttpResponse DoHttpPostRequest(string url, SocialQueryString query, SocialPostData postData, bool isMultipart) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize a new instance of SocialQueryString if the one specified is NULL
            if (query == null) query = new SocialQueryString();

            // Append the access token to the query string if present in the client and not already
            // specified in the query string
            if (!query.ContainsKey("access_token") && !String.IsNullOrWhiteSpace(AccessToken)) {
                query.Add("access_token", AccessToken);
            }

            // Append the query string to the URL
            if (!query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Initialize a new HTTP request
            SocialHttpRequest request = new SocialHttpRequest {
                Url = url,
                Method = "POST"
            };

            // Add the authorization header if the "AccessToken" property is specified
            if (!String.IsNullOrWhiteSpace(AccessToken)) {
                request.Authorization = "OAuth " + AccessToken;
            }

            // Get the HTTP response
            return request.GetResponse();

        }

        #endregion

    }

}