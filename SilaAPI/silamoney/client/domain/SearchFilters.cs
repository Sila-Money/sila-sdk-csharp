using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SearchFilters object used in the GetTransactionsMsg object
    /// </summary>
    public partial class SearchFilters
    {
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
        /// Integer field used in the SearchFilters object to save per Page
        /// </summary>
        [DataMember(Name = "per_page", EmitDefaultValue = false)]
        public int? PerPage { get; set; }
        /// <summary>
        /// Decimal field used in the SearchFilters object to save max sila amount
        /// </summary>
        [DataMember(Name = "max_sila_amount", EmitDefaultValue = false)]
        public decimal? MaxSilaAmount { get; set; }
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
        /// Boolean field used in the SearchFilters object to save sort ascending
        /// </summary>
        [DataMember(Name = "sort_ascending", EmitDefaultValue = false)]
        public bool? SortAscending { get; set; }
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
        /// Integer field used in the SearchFilters object to save page
        /// </summary>
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public int? Page { get; set; }
        /// <summary>
        /// Decimal field used in the SearchFilters object to save min sila amount
        /// </summary>
        [DataMember(Name = "min_sila_amount", EmitDefaultValue = false)]
        public decimal? MinSilaAmount { get; set; }

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
        /// <returns></returns>
        public SearchFilters(string transactionId = default,
            string referenceId = default,
            Statuses[] statuses = default,
            TransactionTypes[] transactionTypes = default,
            decimal? maxSilaAmount = default,
            decimal? minSilaAmount = default,
            int? startEpoch = default,
            int? endEpoch = default,
            int? page = default,
            int? perPage = default,
            bool? sortAscending = default,
            bool? showTimelines = default
            )
        {
            this.TransactionId = transactionId;
            if (this.PerPage != null)
            {
                if (this.PerPage >= 1 && this.PerPage <= 100)
                {
                    this.PerPage = perPage;
                }
                else
                {
                    throw new InvalidDataException("perPage must be between 1 and 100");
                }
            }
            else
            {
                this.PerPage = perPage;
            }
            this.SetTransactionTypes(transactionTypes);
            this.MaxSilaAmount = maxSilaAmount;
            this.ReferenceId = referenceId;
            this.ShowTimelines = showTimelines;
            this.SortAscending = sortAscending;
            this.EndEpoch = endEpoch;
            this.StartEpoch = startEpoch;
            this.SetStatuses(statuses);
            this.Page = page;
            this.MinSilaAmount = minSilaAmount;
        }
    }
}
