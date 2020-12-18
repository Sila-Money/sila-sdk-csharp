using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// TransactionsResult used in the GetTransactionsResponse object
    /// </summary>
    public class GetTransactionsResult
    {
        /// <summary>
        /// Boolean field used in the GetTransactionsResult to save success value
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
        /// <summary>
        /// String field used to indicate if the api call was successful
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
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
        public List<Transaction> Transactions { get; set; }
    }
}
