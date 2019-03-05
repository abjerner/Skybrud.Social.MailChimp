using Skybrud.Essentials.Http;
using Skybrud.Social.MailChimp.Objects.Authentication;

namespace Skybrud.Social.MailChimp.Responses.Authentication {

    /// <summary>
    /// Class representing the OAuth 2.0 token response from the MailChimp API.
    /// </summary>
    public class MailChimpTokenResponse : MailChimpResponse<MailChimpTokenInfo> {

        #region Constructors

        private MailChimpTokenResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MailChimpTokenInfo.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MailChimpTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MailChimpTokenResponse</code>.</returns>
        public static MailChimpTokenResponse ParseResponse(IHttpResponse response) {
            return response == null ? null : new MailChimpTokenResponse(response);
        }

        #endregion

    }

}