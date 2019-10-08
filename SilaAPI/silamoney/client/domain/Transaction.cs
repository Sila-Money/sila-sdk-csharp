using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    public class Transaction
    {
        [JsonProperty("user_handle")]
        public string userHandle { get; set; }
        [JsonProperty("reference_id")]
        public string referenceId { get; set; }
        [JsonProperty("transaction_id")]
        public string transactionId { get; set; }
        [JsonProperty("transaction_hash")]
        public string transactionHash { get; set; }
        [JsonProperty("transaction_type")]
        public string transactionType { get; set; }
        [JsonProperty("sila_amount")]
        public float silaAmount { get; set; }
        [JsonProperty("bank_account_name")]
        public string bankAccountName { get; set; }
        [JsonProperty("handle_address")]
        public string handleAddress { get; set; }
        public string status { get; set; }
        [JsonProperty("usd_status")]
        public string usdStatus { get; set; }
        [JsonProperty("token_status")]
        public string tokenStatus { get; set; }
        public string created { get; set; }
        [JsonProperty("last_update")]
        public string lastUpdate { get; set; }
        [JsonProperty("created_epoch")]
        public long createdEpoch { get; set; }
        [JsonProperty("last_update_epoch")]
        public long lastUpdateEpoch { get; set; }
        public List<TimeLine> timeLines { get; set; }
    }
}
