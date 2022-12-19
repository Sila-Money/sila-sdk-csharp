using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetWalletStatementDataMsg object used in the get_wallet_statement_data endpoint
    /// </summary>
    [DataContract]
    public partial class GetStatementsDataMsg
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
        public StatementSearchFilters SearchFilters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "wallet_id", EmitDefaultValue = false)]
        public string WalletId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="walletId"></param>
        /// <param name="searchFilters"></param>
        public GetStatementsDataMsg(string userHandle, string authHandle, string walletId, StatementSearchFilters searchFilters = null)
        {
            this.Header = new Header(userHandle, authHandle);
            this.SearchFilters = searchFilters;
            this.Message = "get_statement_data_msg";
            this.WalletId = walletId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="searchFilters"></param>
        public GetStatementsDataMsg(string userHandle, string authHandle, StatementSearchFilters searchFilters = null)
        {
            this.Header = new Header(userHandle, authHandle);
            this.SearchFilters = searchFilters;
            this.Message = "get_statements_data_msg";
        }


    }
}
