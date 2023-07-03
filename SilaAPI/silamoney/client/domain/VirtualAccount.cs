using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class VirtualAccount
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account_id")]
        public string VirtualAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account_name")]
        public string VirtualAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_epoch")]
        public long? CreatedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("closed_epoch")]
        public string ClosedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("closed")]
        public bool Closed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_credit_enabled")]
        public bool AchCreditEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_debit_enabled")]
        public bool AchDebitEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("statements_enabled")]
        public bool StatementsEnabled { get; set; }
    }
}
