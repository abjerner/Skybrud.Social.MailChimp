using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Mailchimp.Models {

    /// <summary>
    /// Class representing a basic object from the Mailchimp API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class MailchimpObject : JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
        protected MailchimpObject(JObject obj) : base(obj) { }

        #endregion

    }

}