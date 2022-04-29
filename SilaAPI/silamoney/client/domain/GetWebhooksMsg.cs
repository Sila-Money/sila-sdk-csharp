using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetWebhooksMsg object used in the GetWebhooks endpoint
    /// </summary>
    [DataContract]
    public partial class GetWebhooksMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "search_filters", EmitDefaultValue = false)]
        public WebhooksSearchFilters SearchFilters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="searchFilters"></param>
        public GetWebhooksMsg(string userHandle, string authHandle, WebhooksSearchFilters searchFilters = null)
        {
            this.Header = new Header(userHandle, authHandle);
            this.SearchFilters = searchFilters;
        }
    }
}
