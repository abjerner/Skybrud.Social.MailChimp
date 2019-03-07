using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mailchimp.Models.Users {

    /// <summary>
    /// Class representing a user of a Mailchimp account.
    /// </summary>
    public class MailchimpUser : MailchimpObject {

        #region Properties
        
        /// <summary>
        /// Gets the ID of the account user.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the username of the Mailchimp user.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the role of the user.
        /// </summary>
        public string Role { get; }

        /// <summary>
        /// Gets the avatar URL of the user.
        /// </summary>
        public string Avatar { get; }

        /// <summary>
        /// Gets the ID of the global Mailchimp user.
        /// </summary>
        public long GlobalUserId { get; }

        /// <summary>
        /// Gets the unique ID related to the current data center.
        /// </summary>
        public string DataCenterUniqueId { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the user.</param>
        protected MailchimpUser(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Username = obj.GetString("username");
            Name = obj.GetString("name");
            Email = obj.GetString("email");
            Role = obj.GetString("role");
            Avatar = obj.GetString("avatar");
            GlobalUserId = obj.GetInt64("global_user_id");
            DataCenterUniqueId = obj.GetString("dc_unique_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MailchimpUser"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static MailchimpUser Parse(JObject obj) {
            return obj == null ? null : new MailchimpUser(obj);
        }

        #endregion

    }

}