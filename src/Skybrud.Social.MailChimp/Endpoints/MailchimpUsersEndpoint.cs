using Skybrud.Social.Mailchimp.Endpoints.Raw;
using Skybrud.Social.Mailchimp.Responses.Users;

namespace Skybrud.Social.Mailchimp.Endpoints {

    /// <summary>
    /// Class representing the users endpoint.
    /// </summary>
    public class MailchimpUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Mailchimp service.
        /// </summary>
        public MailchimpService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public MailchimpUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal MailchimpUsersEndpoint(MailchimpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of users of the account of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>MailchimpGetUsersResponse</code> representing the response.</returns>
        /// <see>
        ///     <cref>https://apidocs.Mailchimp.com/api/2.0/users/logins.php</cref>
        /// </see>
        public MailchimpGetUsersResponse GetUsers() {
            return MailchimpGetUsersResponse.ParseResponse(Raw.GetUsers());
        }

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>MailchimpGetUserResponse</code> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://apidocs.Mailchimp.com/api/2.0/users/profile.php</cref>
        /// </see>
        public MailchimpGetUserResponse GetProfile() {
            return MailchimpGetUserResponse.ParseResponse(Raw.GetProfile());
        }

        #endregion

    }

}