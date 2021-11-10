using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Detail
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity")]
        public string Entity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("outcome")]
        public string Outcome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction")]
        public string Transaction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("kyc")]
        public string KYC { get; set; }
    }
}
