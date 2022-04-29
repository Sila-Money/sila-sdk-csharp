using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetInstitutionsMsg object used in the GetInstitutions endpoint
    /// </summary>
    [DataContract]
    public partial class GetInstitutionsMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "search_filters", EmitDefaultValue = false)]
        public InstitutionSearchFilters SearchFilters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authHandle"></param>
        /// <param name="searchFilters"></param>
        public GetInstitutionsMsg(string authHandle, InstitutionSearchFilters searchFilters = null)
        {
            this.Header = new Header(null, authHandle);
            this.SearchFilters = searchFilters;
        }
    }
}
