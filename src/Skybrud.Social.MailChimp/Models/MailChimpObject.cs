using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Mailchimp.Models {

    /// <summary>
    /// Class representing a basic object from the Mailchimp API derived from an instance of <code>JObject</code>.
    /// </summary>
    public class MailchimpObject : JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> representing the object.</param>
        protected MailchimpObject(JObject obj) : base(obj) { }

        #endregion

    }

}