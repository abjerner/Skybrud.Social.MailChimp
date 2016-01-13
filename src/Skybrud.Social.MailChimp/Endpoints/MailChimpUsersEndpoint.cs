using Skybrud.Social.MailChimp.Endpoints.Raw;
using Skybrud.Social.MailChimp.Responses.Users;

namespace Skybrud.Social.MailChimp.Endpoints {

    /// <summary>
    /// Class representing the users endpoint.
    /// </summary>
    public class MailChimpUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the MailChimp service.
        /// </summary>
        public MailChimpService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public MailChimpUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal MailChimpUsersEndpoint(MailChimpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of users of the account of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>MailChimpGetUsersResponse</code> representing the response.</returns>
        public MailChimpGetUsersResponse GetUsers() {
            return MailChimpGetUsersResponse.ParseResponse(Raw.GetUsers());
        }

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>MailChimpGetUserResponse</code> representing the raw response.</returns>
        public MailChimpGetUserResponse GetProfile() {
            return MailChimpGetUserResponse.ParseResponse(Raw.GetProfile());
        }

        #endregion

    }

}