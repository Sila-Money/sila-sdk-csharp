using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.refactored.domain
{
    public class SearchFilters
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        [JsonProperty("show_timelines")]
        public bool? ShowTimelines { get; set; }
        [JsonProperty("sort_ascending")]
        public bool? SortAscending { get; set; }
        [JsonProperty("max_sila_amount")]
        public int? MaxSilaAmount { get; set; }
        [JsonProperty("min_sila_amount")]
        public int? MinSilaAmount { get; set; }
        [JsonProperty("statuses")]
        public List<string> Statuses { get; set; }
        [JsonProperty("start_epoch")]
        public int? StartEpoch { get; set; }
        [JsonProperty("end_epoch")]
        public int? EndEpoch { get; set; }
        [JsonProperty("page")]
        public int? Page { get; set; }
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }
        [JsonProperty("transaction_types")]
        public List<string> TransactionTypes { get; set; }
        [JsonProperty("bank_account_name")]
        public string BankAccountName { get; set; }
    }
}
