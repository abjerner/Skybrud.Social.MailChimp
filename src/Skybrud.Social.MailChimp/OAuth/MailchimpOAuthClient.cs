﻿using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Mailchimp.Endpoints.Raw;
using Skybrud.Social.Mailchimp.Responses.Authentication;

namespace Skybrud.Social.Mailchimp.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Mailchimp API as well as any OAuth 2.0 communication.
    /// </summary>
    public class MailchimpOAuthClient : HttpClient {

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
        /// Gets a reference to the raw lists endpoint.
        /// </summary>
        public MailchimpListsRawEndpoint Lists { get; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public MailchimpUsersRawEndpoint Users { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public MailchimpOAuthClient() {
            Lists = new MailchimpListsRawEndpoint(this);
            Users = new MailchimpUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="clientId"/> and <paramref name="clientSecret"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public MailchimpOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="clientId"/>, <paramref name="clientSecret"/> and <paramref name="redirectUri"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public MailchimpOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/>state.
        /// </summary>
        /// <param name="state">The state to send to the Mailchimp OAuth login page.</param>
        /// <returns>An authorization URL based on <paramref name="state"/>.</returns>
        public string GetAuthorizationUrl(string state) {
            if (String.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
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
        /// <param name="authCode">The authorization code received from the Mailchimp OAuth dialog.</param>
        /// <returns>An access token based on the specified <paramref name="authCode"/>.</returns>
        public MailchimpTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Some validation
            if (String.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException(nameof(authCode));

            // Initialize the query string
            IHttpPostData query = new HttpPostData {
                {"grant_type", "authorization_code"},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri},
                {"code", authCode }
            };

            // Make the call to the API
            IHttpResponse response = HttpUtils.Http.DoHttpPostRequest("https://login.mailchimp.com/oauth2/token", null, query);

            // Parse the response
            return MailchimpTokenResponse.ParseResponse(response);

        }

        /// <summary>
        /// Gets metadata about the authenticated Mailchimp user.
        /// </summary>
        /// <returns>An instance of <see cref="MailchimpMetadataResponse"/> representing the response.</returns>
        public MailchimpMetadataResponse GetMetadata()  {
        
            // Some validation
            if (String.IsNullOrWhiteSpace(AccessToken)) throw new PropertyNotSetException(nameof(AccessToken));

            // Make the call to the API
            IHttpResponse response = DoHttpGetRequest("https://login.mailchimp.com/oauth2/metadata");

            // Parse the response
            return MailchimpMetadataResponse.ParseResponse(response);

        }

        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Initialize a new instance of HttpQueryString if the one specified is NULL
            if (request.QueryString == null) request.QueryString = new HttpQueryString();

            if (String.IsNullOrWhiteSpace(ApiKey) == false && request.QueryString.ContainsKey("apikey") == false) {
                request.QueryString.Add("apikey", ApiKey);
            }

            if (String.IsNullOrWhiteSpace(AccessToken) == false) {
                request.Headers.Authorization = $"Bearer {AccessToken}";
            }

            // Append the API endpoint
            if (request.Url.StartsWith("/")) {
                if (String.IsNullOrWhiteSpace(ApiEndpoint)) throw new PropertyNotSetException(nameof(ApiEndpoint));
                request.Url = ApiEndpoint + request.Url;
            }

        }

        #endregion

    }

}