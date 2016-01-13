using Skybrud.Social.Http;
using Skybrud.Social.MailChimp.Objects.Users;

namespace Skybrud.Social.MailChimp.Responses.Users {

    /// <summary>
    /// Class representing a call to get information a single account user.
    /// </summary>
    public class MailChimpGetUserResponse : MailChimpResponse<MailChimpUser> {

        #region Constructors

        private MailChimpGetUserResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MailChimpUser.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MailChimpGetUserResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MailChimpGetUserResponse</code>.</returns>
        public static MailChimpGetUserResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new MailChimpGetUserResponse(response);
        }

        #endregion

    }

}