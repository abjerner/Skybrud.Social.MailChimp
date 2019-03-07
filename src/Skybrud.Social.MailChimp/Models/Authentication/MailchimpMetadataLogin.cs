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
        public string Email { get; }

        /// <summary>
        /// Gets the avatar URL of the Mailchimp user.
        /// </summary>
        public string Avatar { get; }

        /// <summary>
        /// Gets the ID of the Mailchimp user.
        /// </summary>
        public long LoginId { get; }

        /// <summary>
        /// Gets the login name of the Mailchimp user.
        /// </summary>
        public string LoginName { get; }

        /// <summary>
        /// Gets the login email address of the Mailchimp user.
        /// </summary>
        public string LoginEmail { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the login.</param>
        protected MailchimpMetadataLogin(JObject obj) : base(obj) {
            Email = obj.GetString("email");
            Avatar = obj.GetString("avatar");
            LoginId = obj.GetInt64("login_id");
            LoginName = obj.GetString("login_name");
            LoginEmail = obj.GetString("login_email");
        }

        #endregion

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MailchimpMetadataLogin"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static MailchimpMetadataLogin Parse(JObject obj) {
            return obj == null ? null : new MailchimpMetadataLogin(obj);
        }

    }

}