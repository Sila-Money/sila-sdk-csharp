using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sila.API.Client.Domain
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
        /// 
        /// </summary>
        [JsonProperty("sila_amount")]
        public float? Amount { get; set; }
        /// <summary>
        /// Int field value used in the Transaction objet to save sila_amount
        /// </summary>
        public int SilaAmount { get { return (int)Amount; } }
        /// <summary>
        /// String field value used in the Transaction objet to save bank_account_name
        /// </summary>
        [JsonProperty("bank_account_name")]
        public string BankAccountName { get; set; }
        /// <summary>
        /// String field value used in the Transaction objet to save card_name
        /// </summary>
        [JsonProperty("card_name")]
        public string CardName { get; set; }
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
        public List<Timeline> Timeline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("error_msg")]
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("return_code")]
        public string ReturnCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("return_desc")]
        public string ReturnDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("trace_number")]
        public string TraceNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addenda")]
        public string Addenda { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sila_ledger_type")]
        public string SilaLedgerType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("destination_id")]
        public string DestinationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("submitted")]
        public string Submitted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("submitted_epoch")]
        public string SubmittedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("effective_epoch")]
        public string EffectiveEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("destination_sila_ledger_type")]
        public string DestinationSilaLedgerType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ledger_account_id")]
        public string LedgerAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("destination_ledger_account_id")]
        public string DestinationLedgerAccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("child_transactions")]
        public List<Transaction> ChildTransactions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sec_code")]
        public string SecCode { get; set; }
    }
}
