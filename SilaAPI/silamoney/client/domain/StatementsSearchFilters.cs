using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SearchFilters object used in the Statements
    /// </summary>
    [DataContract]
    public partial class StatementsSearchFilters
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "start_date", EmitDefaultValue = false)]
        public string StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "end_date", EmitDefaultValue = false)]
        public string EndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "user_name", EmitDefaultValue = false)]
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "user_handle", EmitDefaultValue = false)]
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "account_type", EmitDefaultValue = false)]
        public string AccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }
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
