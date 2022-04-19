using Newtonsoft.Json;
using Sila.API.Client.Domain;
namespace Sila.API.Client.Accounts
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
        public string AccountName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("match_score")]
        public float? MatchScore { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_owner_name")]
        public string AccountOwnerName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity_name")]
        public string EntityName { get; private set; }
    }
}