using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mailchimp.Models.Authentication {

    /// <summary>
    /// Class representing the response body of a call to get metadata about the authenticated Mailchimp user.
    /// </summary>
    public class MailchimpMetadata : MailchimpObject {

        #region Properties

        /// <summary>
        /// Gets the data center of the user/account.
        /// </summary>
        public string DataCenter { get; }

        /// <summary>
        /// Gets the role of the user.
        /// </summary>
        public string Role { get; }

        /// <summary>
        /// Gets the name of the account.
        /// </summary>
        public string AccountName { get; }

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public long UserId { get; }

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public MailchimpMetadataLogin Login { get; }

        /// <summary>
        /// Gets the login URL of the account.
        /// </summary>
        public string LoginUrl { get; }

        /// <summary>
        /// Gets the API endpoint of the user or account.
        /// </summary>
        public string ApiEndpoint { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the meta data.</param>
        protected MailchimpMetadata(JObject obj) : base(obj) {
            DataCenter = obj.GetString("dc");
            AccountName = obj.GetString("accountname");
            Role = obj.GetString("role");
            UserId = obj.GetInt64("user_id");
            Login = obj.GetObject("login", MailchimpMetadataLogin.Parse);
            LoginUrl = obj.GetString("login_url");
            ApiEndpoint = obj.GetString("api_endpoint");
        }

        #endregion

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MailchimpMetadata"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static MailchimpMetadata Parse(JObject obj) {
            return obj == null ? null : new MailchimpMetadata(obj);
        }

    }

}