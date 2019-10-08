using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    public class GetTransactionsResult
    {
        public bool success { get; set; }
        public int page { get; set; }
        [JsonProperty("returned_count")]
        public int returnedCount { get; set; }
        [JsonProperty("total_count")]
        public int totalCount { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
