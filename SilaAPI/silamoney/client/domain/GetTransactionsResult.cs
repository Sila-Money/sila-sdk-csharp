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
        public bool success { get; set; }
        /// <summary>
        /// Integer field used in the GetTransactionsResult to save page
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// Integer field used in the GetTransactionsResult to save returned count
        /// </summary>
        [JsonProperty("returned_count")]
        public int returnedCount { get; set; }
        /// <summary>
        /// Integer field used in the GetTransactionsResult to save total count
        /// </summary>
        [JsonProperty("total_count")]
        public int totalCount { get; set; }
        /// <summary>
        /// List of Transaction objects used in the GetTransactionsResult to save transactions
        /// </summary>
        public List<Transaction> transactions { get; set; }
    }
}
