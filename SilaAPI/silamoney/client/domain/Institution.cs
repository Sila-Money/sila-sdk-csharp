using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// A financial instution, its details, and which Plaid products are supported.
    /// </summary>
    public class Institution
    {
        /// <summary>
        /// The official name of the institution as listed in the Federal Reserve's ACH directory
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }
        /// <summary>
        /// Main office or branch O=main B=branch
        /// </summary>
        [DataMember(Name = "office_code", EmitDefaultValue = false)]
        public string OfficeCode { get; set; }
        /// <summary>
        /// The institution's routing number
        /// </summary>
        [DataMember(Name = "routing_number", EmitDefaultValue = false)]
        public string RoutingNumber { get; set; }
        /// <summary>
        /// The code indicating the ABA number to be used to route or send ACH items to the RFI
        /// </summary>
        [DataMember(Name = "record_type_code", EmitDefaultValue = false)]
        public string RecordTypeCode { get; set; }
        /// <summary>
        /// The date of the last change to this routing number. Format is "YYYY-MM-DD"
        /// </summary>
        [DataMember(Name = "change_date", EmitDefaultValue = false)]
        public string ChangeDate { get; set; }
        /// <summary>
        /// The institution's new routing number resulting from a merger or new number issuance
        /// </summary>
        [DataMember(Name = "new_routing_number", EmitDefaultValue = false)]
        public string NewRoutingNumber { get; set; }
        /// <summary>
        /// The institution's address
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public Address Address { get; set; }
        /// <summary>
        /// The institution's phone number
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public string Phone { get; set; }
        /// <summary>
        /// Code is based on the customers receiver code
        /// </summary>
        [DataMember(Name = "institution_status_code", EmitDefaultValue = false)]
        public string InstitutionStatusCode { get; set; }
        /// <summary>
        /// Data view code
        /// </summary>
        [DataMember(Name = "data_view_code", EmitDefaultValue = false)]
        public string DataViewCode { get; set; }
        /// <summary>
        /// Lists the Plaid products that are supported by this institution
        /// </summary>
        [DataMember(Name = "products", EmitDefaultValue = false)]
        public List<string> Products { get; set; }
    }
}