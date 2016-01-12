using System;
using System.Text.RegularExpressions;
using Skybrud.Social.MailChimp.Endpoints;
using Skybrud.Social.MailChimp.OAuth;

namespace Skybrud.Social.MailChimp {

    /// <summary>
    /// Class working as an entry point to the MailChimp API.
    /// </summary>
    public class MailChimpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the MailChimp API.
        /// </summary>
        public MailChimpOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public MailChimpUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        private MailChimpService(MailChimpOAuthClient client) {
            Client = client;
            Users = new MailChimpUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <code>apiKey</code>.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <returns>Returns an instance of <code>MailChimpService</code>.</returns>
        public static MailChimpService GetFromApiKey(string apiKey) {

            // Do we have an API key?
            if (String.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException("apiKey");

            //
            Match match = Regex.Match(apiKey, "^[a-z0-9]+-([a-z0-9]+)$");
            if (!match.Success) throw new ArgumentException("Specified API key doesn't appear to be valid.", "apiKey");

            // Initialize a new OAuth client
            MailChimpOAuthClient client = new MailChimpOAuthClient {
                ApiKey = apiKey,
                ApiEndpoint = "https://" + match.Groups[1].Value + ".api.mailchimp.com"
            };

            // Return a new service instance
            return new MailChimpService(client);

        }

        /// <summary>
        /// Initializes a new instance from the specified <code>accessToken</code> and <code>apiEndpoint</code>.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="apiEndpoint"></param>
        /// <returns>Returns an instance of <code>MailChimpService</code>.</returns>
        public static MailChimpService GetFromAccessToken(string accessToken, string apiEndpoint) {
            
            // Initialize a new OAuth client
            MailChimpOAuthClient client = new MailChimpOAuthClient {
                AccessToken = accessToken,
                ApiEndpoint = Regex.IsMatch(apiEndpoint, "^[a-z0-9]+$") ? "https://" + apiEndpoint + ".api.mailchimp.com" : apiEndpoint
            };

            // Return a new service instance
            return new MailChimpService(client);

        }

        #endregion

    }

}