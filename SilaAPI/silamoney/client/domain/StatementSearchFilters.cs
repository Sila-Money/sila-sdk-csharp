using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SearchFilters object used in the GetStatementsData and GetWalletStatementData methods
    /// </summary>
    [DataContract]
    public partial class StatementSearchFilters
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "start_month", EmitDefaultValue = false)]
        public string StartMonth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "end_month", EmitDefaultValue = false)]
        public string EndMonth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "month", EmitDefaultValue = false)]
        public string Month { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public int Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "per_page", EmitDefaultValue = false)]
        public int PerPage { get; set; }
    }
}
