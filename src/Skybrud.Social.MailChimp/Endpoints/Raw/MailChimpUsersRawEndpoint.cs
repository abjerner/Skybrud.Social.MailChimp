using Skybrud.Social.Http;
using Skybrud.Social.MailChimp.OAuth;

namespace Skybrud.Social.MailChimp.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw users endpoint.
    /// </summary>
    public class MailChimpUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public MailChimpOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal MailChimpUsersRawEndpoint(MailChimpOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of users of the account of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the raw response.</returns>
        public SocialHttpResponse GetUsers() {
            return Client.DoHttpGetRequest("/2.0/users/logins");
        }

        #endregion

    }

}