using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SearchFilters object used in the GetInstitutions method
    /// </summary>
    [DataContract]
    public partial class InstitutionSearchFilters
    {
        /// <summary>
        /// </summary>
        [DataMember(Name = "institution_name", EmitDefaultValue = false)]
        public string InstitutionName { get; set; }
        /// <summary>
        /// </summary>
        [DataMember(Name = "routing_number", EmitDefaultValue = false)]
        public string RoutingNumber { get; set; }
        /// <summary>
        /// </summary>
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public int Page { get; set; }
        /// <summary>
        /// </summary>
        [DataMember(Name = "per_page", EmitDefaultValue = false)]
        public int PerPage { get; set; }
    }
}
