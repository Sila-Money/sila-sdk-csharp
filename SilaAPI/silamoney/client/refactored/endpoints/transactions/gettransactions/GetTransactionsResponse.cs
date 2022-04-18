using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class GetTransactionsResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("returned_count")]
        public int ReturnedCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; private set; }
    }
}
