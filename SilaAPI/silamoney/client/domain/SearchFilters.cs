using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SearchFilters object used in the GetTransactionsMsg object
    /// </summary>
    [DataContract]
    public partial class SearchFilters : SearchFilterBase
    {
        /// <summary>
        /// Array used to set the transaction types in the search filters.
        /// </summary>
        [DataMember(Name = "transaction_types", EmitDefaultValue = false)]
        private TransactionTypes[] transactionTypesOption;

        /// <summary>
        /// Enum used in the SearchFilters object to select transaction type
        /// </summary>
        public TransactionTypes[] GetTransactionTypes()
        {
            return transactionTypesOption;
        }

        /// <summary>
        /// Enum used in the SearchFilters object to select transaction type
        /// </summary>
        public void SetTransactionTypes(TransactionTypes[] value)
        {
            transactionTypesOption = value;
        }

        /// <summary>
        /// /// Array used to set the statuses in the search filters.
        /// </summary>
        [DataMember(Name = "statuses", EmitDefaultValue = false)]
        private Statuses[] statuses;

        /// <summary>
        /// Enum field used in the SearchFilters object to select statuses
        /// </summary>
        public Statuses[] GetStatuses()
        {
            return statuses;
        }

        /// <summary>
        /// Enum field used in the SearchFilters object to select statuses
        /// </summary>
        public void SetStatuses(Statuses[] value)
        {
            statuses = value;
        }

        /// <summary>
        /// String field used in the SearchFilters object to save transaction id
        /// </summary>
        [DataMember(Name = "transaction_id", EmitDefaultValue = false)]
        public string TransactionId { get; set; }
        
        /// <summary>
        /// Int field used in the SearchFilters object to save max sila amount
        /// </summary>
        [DataMember(Name = "max_sila_amount", EmitDefaultValue = false)]
        public int? MaxSilaAmount { get; set; }
        /// <summary>
        /// String field used in the SearchFilters object to save reference id
        /// </summary>
        [DataMember(Name = "reference_id", EmitDefaultValue = false)]
        public string ReferenceId { get; set; }
        /// <summary>
        /// Boolean field used in the SearchFilters object to save show time lines
        /// </summary>
        [DataMember(Name = "show_timelines", EmitDefaultValue = false)]
        public bool? ShowTimelines { get; set; }
        
        /// <summary>
        /// Integer field used in the SearchFilters object to save end epoch
        /// </summary>
        [DataMember(Name = "end_epoch", EmitDefaultValue = false)]
        public int? EndEpoch { get; set; }
        /// <summary>
        /// Integer field used in the SearchFilters object to save start epoch
        /// </summary>
        [DataMember(Name = "start_epoch", EmitDefaultValue = false)]
        public int? StartEpoch { get; set; }
        
        /// <summary>
        /// Int field used in the SearchFilters object to save min sila amount
        /// </summary>
        [DataMember(Name = "min_sila_amount", EmitDefaultValue = false)]
        public int? MinSilaAmount { get; set; }           

        /// <summary>
        /// </summary>
        [DataMember(Name = "bank_account_name", EmitDefaultValue = false)]
        public string BankAccountName { get; set; }

        /// <summary>
        /// </summary>
        [DataMember(Name = "blockchain_address", EmitDefaultValue = false)]
        public string BlockchainAddress { get; set; }

        /// <summary>
        /// SearchFilters constructor
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="referenceId"></param>
        /// <param name="statuses"></param>
        /// <param name="transactionTypes"></param>
        /// <param name="maxSilaAmount"></param>
        /// <param name="minSilaAmount"></param>
        /// <param name="startEpoch"></param>
        /// <param name="endEpoch"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="sortAscending"></param>
        /// <param name="showTimelines"></param>
        /// <param name="bankAccountName"></param>
        /// <param name="blockchainAddress"></param>                     
        /// <returns></returns>
        public SearchFilters(string transactionId = default,
            string referenceId = default,
            Statuses[] statuses = default,
            TransactionTypes[] transactionTypes = default,
            int? maxSilaAmount = default,
            int? minSilaAmount = default,
            int? startEpoch = default,
            int? endEpoch = default,
            int? page = default,
            int? perPage = default,
            bool? sortAscending = default,
            bool? showTimelines = default,
            string bankAccountName = default,
            string blockchainAddress = default
            ) : base(page, perPage, sortAscending)
        {
            
            TransactionId = transactionId;
            SetTransactionTypes(transactionTypes);
            MaxSilaAmount = maxSilaAmount;
            ReferenceId = referenceId;
            ShowTimelines = showTimelines;
            EndEpoch = endEpoch;
            StartEpoch = startEpoch;
            SetStatuses(statuses);
            MinSilaAmount = minSilaAmount;
            BankAccountName = bankAccountName;
            BlockchainAddress = blockchainAddress;
        }
    }
}
