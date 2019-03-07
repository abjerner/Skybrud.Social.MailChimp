using Skybrud.Essentials.Http;
using Skybrud.Social.Mailchimp.Models.Authentication;

namespace Skybrud.Social.Mailchimp.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to get metadata about the authenticated Mailchimp user.
    /// </summary>
    public class MailchimpMetadataResponse : MailchimpResponse<MailchimpMetadata> {

        #region Constructors

        private MailchimpMetadataResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MailchimpMetadata.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MailchimpMetadataResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="MailchimpMetadataResponse"/>.</returns>
        public static MailchimpMetadataResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new MailchimpMetadataResponse(response);
        }

        #endregion

    }

}