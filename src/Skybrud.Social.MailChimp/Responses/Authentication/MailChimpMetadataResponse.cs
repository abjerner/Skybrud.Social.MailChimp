using Skybrud.Social.Http;
using Skybrud.Social.MailChimp.Objects.Authentication;

namespace Skybrud.Social.MailChimp.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to get metadata about the authenticated MailChimp user.
    /// </summary>
    public class MailChimpMetadataResponse : MailChimpResponse<MailChimpMetadata> {

        #region Constructors

        private MailChimpMetadataResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MailChimpMetadata.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MailChimpMetadataResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MailChimpMetadataResponse</code>.</returns>
        public static MailChimpMetadataResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new MailChimpMetadataResponse(response);
        }

        #endregion

    }

}