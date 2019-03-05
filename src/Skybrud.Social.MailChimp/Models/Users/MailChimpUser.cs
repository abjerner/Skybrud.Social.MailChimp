using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.MailChimp.Models.Users {

    /// <summary>
    /// Class representing a user of a MailChimp account.
    /// </summary>
    public class MailChimpUser : MailChimpObject {

        #region Properties
        
        /// <summary>
        /// Gets the ID of the account user.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Gets the username of the MailChimp user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the role of the user.
        /// </summary>
        public string Role { get; private set; }

        /// <summary>
        /// Gets the avatar URL of the user.
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        /// Gets the ID of the global MailChimp user.
        /// </summary>
        public long GlobalUserId { get; private set; }

        /// <summary>
        /// Gets the unique ID related to the current data center.
        /// </summary>
        public string DataCenterUniqueId { get; private set; }

        #endregion

        #region Constructors

        private MailChimpUser(JObject obj) : base(obj) {
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
        /// Parses the specified <code>obj</code> into an instance of <code>MailChimpUser</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        public static MailChimpUser Parse(JObject obj) {
            return obj == null ? null : new MailChimpUser(obj);
        }

        #endregion

    }

}