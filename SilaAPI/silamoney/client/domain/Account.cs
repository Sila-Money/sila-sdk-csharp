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
        public string accountNumber { get; set; }
        /// <summary>
        /// String field used in the Account object to save account name
        /// </summary>
        [JsonProperty("account_name")]
        public string accountName { get; set; }
        /// <summary>
        /// String field used in the Account object to save account type
        /// </summary>
        [JsonProperty("account_type")]
        public string accountType { get; set; }
        /// <summary>
        /// String field used in the Account object to save account status
        /// </summary>
        [JsonProperty("account_status")]
        public string accountStatus { get; set; }
    }
}
