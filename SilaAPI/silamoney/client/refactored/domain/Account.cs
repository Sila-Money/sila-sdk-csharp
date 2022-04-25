using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Account object used in the get_accounts endpoint response
    /// </summary>
    public class Account
    {
        /// <summary>
        /// String field used in the Account object to save account number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        /// <summary>
        /// String field used in the Account object to save routing number
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }
        /// <summary>
        /// String field used in the Account object to save account name
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
        /// <summary>
        /// String field used in the Account object to save account type
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
        /// <summary>
        /// String field used in the Account object to save account status
        /// </summary>
        [JsonProperty("account_status")]
        public string AccountStatus { get; set; }
        /// <summary>
        /// String field used in the Account object to save account status
        /// </summary>
        [JsonProperty("account_link_status")]
        public string AccountLinkStatus { get; set; }
        /// <summary>
        /// String field used in the Account object to save account status
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("match_score")]
        public float? MatchScore { get; set; }

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
        public bool WebDebitVerified { get; set; }
    }
}
