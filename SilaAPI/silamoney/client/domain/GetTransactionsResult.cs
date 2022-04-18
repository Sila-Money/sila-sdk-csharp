using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// TransactionsResult used in the GetTransactionsResponse object
    /// </summary>
    public class GetTransactionsResult : BaseResponse
    {
        /// <summary>
        /// Integer field used in the GetTransactionsResult to save page
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }
        /// <summary>
        /// Integer field used in the GetTransactionsResult to save returned count
        /// </summary>
        [JsonProperty("returned_count")]
        public int ReturnedCount { get; set; }
        /// <summary>
        /// Integer field used in the GetTransactionsResult to save total count
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
        /// <summary>
        /// List of Transaction objects used in the GetTransactionsResult to save transactions
        /// </summary>        
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}

