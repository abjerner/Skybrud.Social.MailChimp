using System;
using System.Text.RegularExpressions;
using Skybrud.Social.Mailchimp.Endpoints;
using Skybrud.Social.Mailchimp.OAuth;

namespace Skybrud.Social.Mailchimp {

    /// <summary>
    /// Class working as an entry point to the Mailchimp API.
    /// </summary>
    public class MailchimpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the Mailchimp API.
        /// </summary>
        public MailchimpOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the lists endpoint.
        /// </summary>
        public MailchimpListsEndpoint Lists { get; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public MailchimpUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        private MailchimpService(MailchimpOAuthClient client) {
            Client = client;
            Lists = new MailchimpListsEndpoint(this);
            Users = new MailchimpUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client to be used for making requests to the Mailchimp API.</param>
        /// <returns>A new instance of <see cref="MailchimpService"/>.</returns>
        public static MailchimpService CreateFromClient(MailchimpOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new MailchimpService(client);
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>apiKey</code>.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <returns>Returns an instance of <code>MailchimpService</code>.</returns>
        public static MailchimpService GetFromApiKey(string apiKey) {

            // Do we have an API key?
            if (String.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException("apiKey");

            //
            Match match = Regex.Match(apiKey, "^[a-z0-9]+-([a-z0-9]+)$");
            if (!match.Success) throw new ArgumentException("Specified API key doesn't appear to be valid.", "apiKey");

            // Initialize a new OAuth client
            MailchimpOAuthClient client = new MailchimpOAuthClient {
                ApiKey = apiKey,
                ApiEndpoint = "https://" + match.Groups[1].Value + ".api.Mailchimp.com"
            };

            // Return a new service instance
            return new MailchimpService(client);

        }

        /// <summary>
        /// Initializes a new instance from the specified <code>accessToken</code> and <code>apiEndpoint</code>.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="apiEndpoint"></param>
        /// <returns>Returns an instance of <code>MailchimpService</code>.</returns>
        public static MailchimpService GetFromAccessToken(string accessToken, string apiEndpoint) {
            
            // Initialize a new OAuth client
            MailchimpOAuthClient client = new MailchimpOAuthClient {
                AccessToken = accessToken,
                ApiEndpoint = Regex.IsMatch(apiEndpoint, "^[a-z0-9]+$") ? "https://" + apiEndpoint + ".api.mailchimp.com" : apiEndpoint
            };

            // Return a new service instance
            return new MailchimpService(client);

        }

        #endregion

    }

}