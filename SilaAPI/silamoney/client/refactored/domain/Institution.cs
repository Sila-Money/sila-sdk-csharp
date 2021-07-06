using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sila.API.Client.Domain
{
    public class Institution
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }
        [DataMember(Name = "office_code", EmitDefaultValue = false)]
        public string OfficeCode { get; set; }
        [DataMember(Name = "routing_number", EmitDefaultValue = false)]
        public string RoutingNumber { get; set; }
        [DataMember(Name = "record_type_code", EmitDefaultValue = false)]
        public string RecordTypeCode { get; set; }
        [DataMember(Name = "change_date", EmitDefaultValue = false)]
        public string ChangeDate { get; set; }
        [DataMember(Name = "new_routing_number", EmitDefaultValue = false)]
        public string NewRoutingNumber { get; set; }
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public Address Address { get; set; }
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public string Phone { get; set; }
        [DataMember(Name = "institution_status_code", EmitDefaultValue = false)]
        public string InstitutionStatusCode { get; set; }
        [DataMember(Name = "data_view_code", EmitDefaultValue = false)]
        public string DataViewCode { get; set; }
        [DataMember(Name = "products", EmitDefaultValue = false)]
        public List<string> Products { get; set; }
    }
}