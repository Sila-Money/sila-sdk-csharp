using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Account object used in the get_accounts endpoint
    /// </summary>
    public class Account
    {
        [JsonProperty("account_number")]
        public string accountNumber { get; set; }
        [JsonProperty("account_name")]
        public string accountName { get; set; }
        [JsonProperty("account_type")]
        public string accountType { get; set; }
        [JsonProperty("account_status")]
        public string accountStatus { get; set; }
    }
}
