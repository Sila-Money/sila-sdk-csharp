using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkAccountResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary> 
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// 
        /// </summary> 
        [JsonProperty("match_score")]
        public decimal? MatchScore { get; set; }

        /// <summary>
        /// 
        /// </summary> 
        [JsonProperty("account_owner_name")]
        public string AccountOwnerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity_name")]
        public string EntityName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("web_debit_verified")]
        public bool? WebDebitVerified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }
    }
}