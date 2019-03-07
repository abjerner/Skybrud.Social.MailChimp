using Skybrud.Essentials.Http;
using Skybrud.Social.Mailchimp.Models.Lists;

namespace Skybrud.Social.Mailchimp.Responses.Lists {

    /// <summary>
    /// Class representing a call to get information a single Mailchimp mailing list.
    /// </summary>
    public class MailchimpGetListResponse : MailchimpResponse<MailchimpList> {

        #region Constructors

        private MailchimpGetListResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MailchimpList.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MailchimpGetListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="MailchimpGetListResponse"/>.</returns>
        public static MailchimpGetListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return response == null ? null : new MailchimpGetListResponse(response);
        }

        #endregion

    }

}