using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.MailChimp.Objects.Authentication {

    /// <summary>
    /// Class representing information about an OAuth access token.
    /// </summary>
    public class MailChimpTokenInfo : MailChimpObject {

        #region Properties

        /// <summary>
        /// Gets the access token of the authenticated user.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets an instance of <code>TimeSpan</code> indicating when the access token will expire. According to the
        /// MailChimp API documentation, an access token will not expire, but this property is still present in the
        /// response. The property value will most likely always be <code>0</code>.
        /// </summary>
        public TimeSpan ExpiresIn { get; private set; }

        #endregion

        #region Constructors

        private MailChimpTokenInfo(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>MailChimpTokenInfo</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        public static MailChimpTokenInfo Parse(JObject obj) {
            return obj == null ? null : new MailChimpTokenInfo(obj);
        }

        #endregion

    }

}