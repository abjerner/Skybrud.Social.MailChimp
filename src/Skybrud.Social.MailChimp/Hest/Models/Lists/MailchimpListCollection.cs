using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mailchimp.Models.Lists {

    /// <summary>
    /// Class representing a collection of Mailchimp mailing lists.
    /// </summary>
    public class MailchimpListCollection {

        #region Properties

        /// <summary>
        /// Gets an array with the lists returned in the response.
        /// </summary>
        public MailchimpList[] Lists { get; }

        /// <summary>
        /// Gets the total number of items matching the query regardless of pagination.
        /// </summary>
        public int TotalItems { get; }

        // TODO: Add support for the "_links" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the list.</param>
        protected MailchimpListCollection(JObject obj) {
            Lists = obj.GetArrayItems("lists", MailchimpList.Parse);
            TotalItems = obj.GetInt32("total_items");
        }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MailchimpListCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static MailchimpListCollection Parse(JObject obj) {
            return obj == null ? null : new MailchimpListCollection(obj);
        }

        #endregion

    }

}