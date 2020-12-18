using Newtonsoft.Json;
using System.Collections.Generic;

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
        public string UserHandle { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save reference_id
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save transaction_id
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save transaction_hash
        /// </summary>
        [JsonProperty("transaction_hash")]
        public string TransactionHash { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save transaction_type
        /// </summary>
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }
        /// <summary>
        /// Float field value used in the Transaction objet to save sila_amount
        /// </summary>
        [JsonProperty("sila_amount")]
        public float SilaAmount { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save bank_account_name
        /// </summary>
        [JsonProperty("bank_account_name")]
        public string BankAccountName { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save handle_address
        /// </summary>
        [JsonProperty("handle_address")]
        public string HandleAddress { get; set; }
        /// <summary>
        /// String field value used in the transaction object to save status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save usd_status
        /// </summary>
        [JsonProperty("usd_status")]
        public string UsdStatus { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save token_status
        /// </summary>
        [JsonProperty("token_status")]
        public string TokenStatus { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save created
        /// </summary>
        [JsonProperty("created")]
        public string Created { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save last_update
        /// </summary>
        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save created_epoch
        /// </summary>
        [JsonProperty("created_epoch")]
        public long CreatedEpoch { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save last_update_epoch
        /// </summary>
        [JsonProperty("last_update_epoch")]
        public long LastUpdateEpoch { get; set; }
        /// <summary>
        /// The transactipon descriptor (if any)
        /// </summary>
        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }
        /// <summary>
        /// The transaction descriptor seen by the end user (if any)
        /// </summary>
        [JsonProperty("descriptor_ach")]
        public string DescriptorAch { get; set; }
        /// <summary>
        /// The company name seen by the end user (if any)
        /// </summary>
        [JsonProperty("ach_name")]
        public string AchName { get; set; }
        /// <summary>
        /// The processing type of the transaction (not available on transfer transaction type)
        /// </summary>
        [JsonProperty("processing_type")]
        public string ProcessingType { get; set; }
        /// <summary>
        /// The destination addrees of the transaction (only available on transfer transaction type)
        /// </summary>
        [JsonProperty("destination_address")]
        public string DestinationAddress { get; set; }
        /// <summary>
        /// The destination handle of the transaction (only available on transfer transaction type)
        /// </summary>
        [JsonProperty("destination_handle")]
        public string DestinationHandle { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save timelines
        /// </summary>
        [JsonProperty("timeline")]
        public List<TimeLine> TimeLine { get; set; }
    }
}
