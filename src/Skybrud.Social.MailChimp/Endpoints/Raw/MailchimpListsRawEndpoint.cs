using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Mailchimp.OAuth;

namespace Skybrud.Social.Mailchimp.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw lists endpoint.
    /// </summary>
    public class MailchimpListsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public MailchimpOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal MailchimpListsRawEndpoint(MailchimpOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a specific list in your Mailchimp account.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.mailchimp.com/documentation/mailchimp/reference/lists/#read-get_lists_list_id</cref>
        /// </see>
        public IHttpResponse GetList(string listId) {
            if (String.IsNullOrWhiteSpace(listId)) throw new ArgumentNullException(nameof(listId));
            return Client.DoHttpGetRequest($"/3.0/lists/{listId}");
        }

        /// <summary>
        /// Gets a collection of all lists of the authenticated account.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.mailchimp.com/documentation/mailchimp/reference/lists/#read-get_lists</cref>
        /// </see>
        public IHttpResponse GetLists() {
            return Client.DoHttpGetRequest("/3.0/lists");
        }

        #endregion

    }

}