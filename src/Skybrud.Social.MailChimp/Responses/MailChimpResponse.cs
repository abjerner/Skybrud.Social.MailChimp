using System;
using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.MailChimp.Responses {

    /// <summary>
    /// Class representing a response from the MailChimp API.
    /// </summary>
    public class MailChimpResponse : SocialResponse {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        protected MailChimpResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            throw new Exception("WTF?\n\n" + response.Body);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the MailChimp API.
    /// </summary>
    public class MailChimpResponse<T> : MailChimpResponse {

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
        protected MailChimpResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}