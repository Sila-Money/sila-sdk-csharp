using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAccountBalanceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("available_balance")]
        public decimal AvailableBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("current_balance")]
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("masked_account_number")]
        public string MaskedAccountNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
    }
}
