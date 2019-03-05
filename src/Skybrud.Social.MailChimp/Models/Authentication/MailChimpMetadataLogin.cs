using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mailchimp.Models.Authentication {

    /// <summary>
    /// Class representing information about a Mailchimp user.
    /// </summary>
    public class MailchimpMetadataLogin : MailchimpObject {

        #region Properties

        /// <summary>
        /// Gets the email address of the Mailchimp user.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the avatar URL of the Mailchimp user.
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        /// Gets the ID of the Mailchimp user.
        /// </summary>
        public long LoginId { get; private set; }

        /// <summary>
        /// Gets the login name of the Mailchimp user.
        /// </summary>
        public string LoginName { get; private set; }

        /// <summary>
        /// Gets the login email address of the Mailchimp user.
        /// </summary>
        public string LoginEmail { get; private set; }

        #endregion

        #region Constructors

        private MailchimpMetadataLogin(JObject obj) : base(obj) {
            Email = obj.GetString("email");
            Avatar = obj.GetString("avatar");
            LoginId = obj.GetInt64("login_id");
            LoginName = obj.GetString("login_name");
            LoginEmail = obj.GetString("login_email");
        }

        #endregion

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>MailchimpMetadataLogin</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        public static MailchimpMetadataLogin Parse(JObject obj) {
            return obj == null ? null : new MailchimpMetadataLogin(obj);
        }

    }

}