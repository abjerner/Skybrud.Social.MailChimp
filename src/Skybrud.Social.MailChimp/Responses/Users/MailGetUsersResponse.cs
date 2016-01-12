using Skybrud.Social.Http;
using Skybrud.Social.MailChimp.Objects.Users;

namespace Skybrud.Social.MailChimp.Responses.Users {

    /// <summary>
    /// Class representing a call to get a list of users of an account.
    /// </summary>
    public class MailGetUsersResponse : MailChimpResponse<MailChimpUser[]> {

        #region Constructors

        private MailGetUsersResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, MailChimpUser.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MailGetUsersResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MailGetUsersResponse</code>.</returns>
        public static MailGetUsersResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new MailGetUsersResponse(response);
        }

        #endregion

    }

}