using Skybrud.Social.Http;
using Skybrud.Social.MailChimp.Objects.Users;

namespace Skybrud.Social.MailChimp.Responses.Users {

    /// <summary>
    /// Class representing a call to get a list of users of an account.
    /// </summary>
    public class MailChimpGetUsersResponse : MailChimpResponse<MailChimpUser[]> {

        #region Constructors

        private MailChimpGetUsersResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, MailChimpUser.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MailChimpGetUsersResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MailChimpGetUsersResponse</code>.</returns>
        public static MailChimpGetUsersResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new MailChimpGetUsersResponse(response);
        }

        #endregion

    }

}