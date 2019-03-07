using Skybrud.Essentials.Http;
using Skybrud.Social.Mailchimp.Models.Authentication;

namespace Skybrud.Social.Mailchimp.Responses.Authentication {

    /// <summary>
    /// Class representing the OAuth 2.0 token response from the Mailchimp API.
    /// </summary>
    public class MailchimpTokenResponse : MailchimpResponse<MailchimpTokenInfo> {

        #region Constructors

        private MailchimpTokenResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MailchimpTokenInfo.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MailchimpTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MailchimpTokenResponse</code>.</returns>
        public static MailchimpTokenResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return response == null ? null : new MailchimpTokenResponse(response);
        }

        #endregion

    }

}