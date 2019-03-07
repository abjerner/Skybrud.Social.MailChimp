using Skybrud.Social.Mailchimp.Endpoints.Raw;
using Skybrud.Social.Mailchimp.Responses.Lists;
using Skybrud.Social.Mailchimp.Responses.Users;

namespace Skybrud.Social.Mailchimp.Endpoints {

    /// <summary>
    /// Class representing the lists endpoint.
    /// </summary>
    public class MailchimpListsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Mailchimp service.
        /// </summary>
        public MailchimpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public MailchimpListsRawEndpoint Raw => Service.Client.Lists;

        #endregion

        #region Constructors

        internal MailchimpListsEndpoint(MailchimpService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a specific list in your Mailchimp account.
        /// </summary>
        /// <returns>An instance of <see cref="MailchimpGetListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.mailchimp.com/documentation/mailchimp/reference/lists/#read-get_lists_list_id</cref>
        /// </see>
        public MailchimpGetListResponse GetList(string listId)  {
            return MailchimpGetListResponse.ParseResponse(Raw.GetList(listId));
        }

        /// <summary>
        /// Gets a collection of all lists of the authenticated account.
        /// </summary>
        /// <returns>An instance of <see cref="MailchimpGetListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.mailchimp.com/documentation/mailchimp/reference/lists/#read-get_lists</cref>
        /// </see>
        public MailchimpGetListsResponse GetLists() {
            return MailchimpGetListsResponse.ParseResponse(Raw.GetLists());
        }

        #endregion

    }

}