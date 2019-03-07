using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mailchimp.Models.Lists {
    
    /// <summary>
    /// Class representing a Mailchimp mailing list.
    /// </summary>
    public class MailchimpList : MailchimpObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the list.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the name of the list.
        /// </summary>
        public string Name { get; }

        // TODO: Add support for the "contact" property

        // TODO: Add support for the "permission_reminder" property

        // TODO: Add support for the "use_archive_bar" property

        // TODO: Add support for the "campaign_defaults" property

        // TODO: Add support for the "notify_on_subscribe" property

        // TODO: Add support for the "notify_on_unsubscribe" property

        // TODO: Add support for the "date_created" property

        // TODO: Add support for the "list_rating" property

        // TODO: Add support for the "email_type_option" property

        // TODO: Add support for the "subscribe_url_short" property

        // TODO: Add support for the "subscribe_url_long" property

        // TODO: Add support for the "beamer_address" property

        // TODO: Add support for the "visibility" property

        // TODO: Add support for the "modules" property

        // TODO: Add support for the "stats" property

        // TODO: Add support for the "_links" property

        // TODO: Add support for the "contact" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the list.</param>
        protected MailchimpList(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Name = obj.GetString("name");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MailchimpListCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static MailchimpList Parse(JObject obj) {
            return obj == null ? null : new MailchimpList(obj);
        }

        #endregion

    }

}