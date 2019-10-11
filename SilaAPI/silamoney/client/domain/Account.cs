using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
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
    }
}
