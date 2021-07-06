using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public class GetInstitutionsResponse : BaseResponse
    {
        [DataMember(Name = "institutions", EmitDefaultValue = false)]
        public List<Institution> Institutions { get; set; }
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public int Page { get; set; }
        [DataMember(Name = "returned_count", EmitDefaultValue = false)]
        public int ReturnedCount { get; set; }
        [DataMember(Name = "total_count", EmitDefaultValue = false)]
        public int TotalCount { get; set; }
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public Pagination Pagination { get; set; }
    }
}