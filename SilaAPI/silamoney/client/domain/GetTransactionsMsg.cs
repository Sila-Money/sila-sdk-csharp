using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// TransactionMsg used in the get_transactions_msg endpoint
    /// </summary>
    public partial class GetTransactionsMsg : BaseMessage
    {
        /// <summary>
        /// Search filters object field used in the GetTransactionsMsg to save search filters
        /// </summary>
        [DataMember(Name = "search_filters", EmitDefaultValue = false)]
        public SearchFilters searchFilters { get; set; }

        /// <summary>
        /// GetTransactionsMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="searchFilters"></param>
        /// <returns></returns>
        public GetTransactionsMsg(string userHandle, string authHandle, SearchFilters searchFilters = default(SearchFilters))
        {
            this.Header = new Header(userHandle, authHandle);
            this.searchFilters = searchFilters;
            this.MessageOption = Message.GetTransactionMsg;
        }
    }
}
