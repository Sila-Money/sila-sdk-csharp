using Newtonsoft.Json;
using Sila.API.Client.Domain;
namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkAccountMxResponse : BaseResponse
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