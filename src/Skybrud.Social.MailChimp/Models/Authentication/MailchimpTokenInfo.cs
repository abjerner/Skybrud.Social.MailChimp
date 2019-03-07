using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mailchimp.Models.Authentication {

    /// <summary>
    /// Class representing information about an OAuth access token.
    /// </summary>
    public class MailchimpTokenInfo : MailchimpObject {

        #region Properties

        /// <summary>
        /// Gets the access token of the authenticated user.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets an instance of <see cref="TimeSpan"/> indicating when the access token will expire. According to the
        /// Mailchimp API documentation, an access token will not expire, but this property is still present in the
        /// response. The property value will most likely always be equal to <see cref="TimeSpan.Zero"/>.
        /// </summary>
        public TimeSpan ExpiresIn { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the token.</param>
        protected MailchimpTokenInfo(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MailchimpTokenInfo"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static MailchimpTokenInfo Parse(JObject obj) {
            return obj == null ? null : new MailchimpTokenInfo(obj);
        }

        #endregion

    }

}