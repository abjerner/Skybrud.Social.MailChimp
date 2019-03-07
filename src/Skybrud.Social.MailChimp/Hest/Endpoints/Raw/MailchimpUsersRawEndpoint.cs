using Skybrud.Essentials.Http;
using Skybrud.Social.Mailchimp.OAuth;

namespace Skybrud.Social.Mailchimp.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw users endpoint.
    /// </summary>
    public class MailchimpUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public MailchimpOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal MailchimpUsersRawEndpoint(MailchimpOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of users of the account of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://apidocs.Mailchimp.com/api/2.0/users/logins.php</cref>
        /// </see>
        public IHttpResponse GetUsers() {
            return Client.DoHttpGetRequest("/2.0/users/logins");
        }

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://apidocs.Mailchimp.com/api/2.0/users/profile.php</cref>
        /// </see>
        public IHttpResponse GetProfile() {
            return Client.DoHttpGetRequest("/2.0/users/profile");
        }

        #endregion

    }

}