using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Mailchimp.Models.Lists;

namespace Skybrud.Social.Mailchimp.Responses.Lists {

    /// <summary>
    /// Class representing a call to get a collection of Mailchimp mailing lists.
    /// </summary>
    public class MailchimpGetListsResponse : MailchimpResponse<MailchimpListCollection> {

        #region Constructors

        private MailchimpGetListsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MailchimpListCollection.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MailchimpGetListsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="MailchimpGetListsResponse"/>.</returns>
        public static MailchimpGetListsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new MailchimpGetListsResponse(response);
        }

        #endregion

    }

}