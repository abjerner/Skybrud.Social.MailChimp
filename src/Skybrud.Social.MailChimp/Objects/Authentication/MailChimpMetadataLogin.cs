using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.MailChimp.Objects.Authentication {

    /// <summary>
    /// Class representing information about a MailChimp user.
    /// </summary>
    public class MailChimpMetadataLogin : MailChimpObject {

        #region Properties

        /// <summary>
        /// Gets the email address of the MailChimp user.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the avatar URL of the MailChimp user.
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        /// Gets the ID of the MailChimp user.
        /// </summary>
        public long LoginId { get; private set; }

        /// <summary>
        /// Gets the login name of the MailChimp user.
        /// </summary>
        public string LoginName { get; private set; }

        /// <summary>
        /// Gets the login email address of the MailChimp user.
        /// </summary>
        public string LoginEmail { get; private set; }

        #endregion

        #region Constructors

        private MailChimpMetadataLogin(JObject obj) : base(obj) {
            Email = obj.GetString("email");
            Avatar = obj.GetString("avatar");
            LoginId = obj.GetInt64("login_id");
            LoginName = obj.GetString("login_name");
            LoginEmail = obj.GetString("login_email");
        }

        #endregion

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>MailChimpMetadataLogin</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        public static MailChimpMetadataLogin Parse(JObject obj) {
            return obj == null ? null : new MailChimpMetadataLogin(obj);
        }

    }

}