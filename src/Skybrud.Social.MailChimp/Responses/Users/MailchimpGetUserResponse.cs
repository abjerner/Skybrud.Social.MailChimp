using Skybrud.Essentials.Http;
using Skybrud.Social.Mailchimp.Models.Users;

namespace Skybrud.Social.Mailchimp.Responses.Users {

    /// <summary>
    /// Class representing a call to get information a single account user.
    /// </summary>
    public class MailchimpGetUserResponse : MailchimpResponse<MailchimpUser> {

        #region Constructors

        private MailchimpGetUserResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MailchimpUser.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MailchimpGetUserResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MailchimpGetUserResponse</code>.</returns>
        public static MailchimpGetUserResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return response == null ? null : new MailchimpGetUserResponse(response);
        }

        #endregion

    }

}