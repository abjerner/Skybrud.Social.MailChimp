using System;
using System.Net;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Mailchimp.Responses {

    /// <summary>
    /// Class representing a response from the Mailchimp API.
    /// </summary>
    public class MailchimpResponse : HttpResponseBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        protected MailchimpResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(IHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            throw new Exception("WTF?\n\n" + response.Body);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Mailchimp API.
    /// </summary>
    public class MailchimpResponse<T> : MailchimpResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        protected MailchimpResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}