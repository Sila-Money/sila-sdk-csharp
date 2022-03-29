using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchFilters
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("show_timelines")]
        public bool? ShowTimelines { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sort_ascending")]
        public bool? SortAscending { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("max_sila_amount")]
        public int? MaxSilaAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("min_sila_amount")]
        public int? MinSilaAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("statuses")]
        public List<string> Statuses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("start_epoch")]
        public int? StartEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("end_epoch")]
        public int? EndEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page")]
        public int? Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_types")]
        public List<string> TransactionTypes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_name")]
        public string BankAccountName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_name")]
        public string CardName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockchain_address")]
        public string BlockchainAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("destination_id")]
        public string DestinationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("processing_type")]
        public ProcessingType ProcessingType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("payment_method_id")]
        public string PaymentMethodId { get; set; }
    }
}
