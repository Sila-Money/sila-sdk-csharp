using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Transaction object used in the GetTransactionsResult object
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// String field value used in the Transaction objet to save user_handle
        /// </summary>
        [JsonProperty("user_handle")]
        public string userHandle { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save reference_id
        /// </summary>
        [JsonProperty("reference_id")]
        public string referenceId { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save transaction_id
        /// </summary>
        [JsonProperty("transaction_id")]
        public string transactionId { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save transaction_hash
        /// </summary>
        [JsonProperty("transaction_hash")]
        public string transactionHash { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save transaction_type
        /// </summary>
        [JsonProperty("transaction_type")]
        public string transactionType { get; set; }
        /// <summary>
        /// Float field value used in the Transaction objet to save sila_amount
        /// </summary>
        [JsonProperty("sila_amount")]
        public float silaAmount { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save bank_account_name
        /// </summary>
        [JsonProperty("bank_account_name")]
        public string bankAccountName { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save handle_address
        /// </summary>
        [JsonProperty("handle_address")]
        public string handleAddress { get; set; }
        public string status { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save usd_status
        /// </summary>
        [JsonProperty("usd_status")]
        public string usdStatus { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save token_status
        /// </summary>
        [JsonProperty("token_status")]
        public string tokenStatus { get; set; }
        public string created { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save last_update
        /// </summary>
        [JsonProperty("last_update")]
        public string lastUpdate { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save created_epoch
        /// </summary>
        [JsonProperty("created_epoch")]
        public long createdEpoch { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save last_update_epoch
        /// </summary>
        [JsonProperty("last_update_epoch")]
        public long lastUpdateEpoch { get; set; }
        public List<TimeLine> timeLines { get; set; }
    }
}
