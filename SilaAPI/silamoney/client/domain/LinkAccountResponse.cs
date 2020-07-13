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
    }
}