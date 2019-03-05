using Skybrud.Essentials.Http;
using Skybrud.Social.Mailchimp.Models.Users;

namespace Skybrud.Social.Mailchimp.Responses.Users {

    /// <summary>
    /// Class representing a call to get a list of users of an account.
    /// </summary>
    public class MailchimpGetUsersResponse : MailchimpResponse<MailchimpUser[]> {

        #region Constructors

        private MailchimpGetUsersResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, MailchimpUser.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MailchimpGetUsersResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MailchimpGetUsersResponse</code>.</returns>
        public static MailchimpGetUsersResponse ParseResponse(IHttpResponse response) {
            return response == null ? null : new MailchimpGetUsersResponse(response);
        }

        #endregion

    }

}