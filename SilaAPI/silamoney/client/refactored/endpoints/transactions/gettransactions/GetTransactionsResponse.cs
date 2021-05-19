using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    public class GetTransactionsResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("page")]
        public int Page { get; private set; }
        [JsonProperty("returned_count")]
        public int ReturnedCount { get; private set; }
        [JsonProperty("total_count")]
        public int TotalCount { get; private set; }
        [JsonProperty("pagination")]
        public Pagination Pagination { get; private set; }
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; private set; }
    }
}