using System.Runtime.Serialization;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Address object used in the entity_msg object
    /// </summary>
    [DataContract]
    public class Address
    {
        /// <summary>
        /// Enum field used in the Address object to select Country
        /// </summary>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; } = "US";
        /// <summary>
        /// String field used in the Address object to save city
        /// </summary>
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }
        /// <summary>
        /// String field used in the Address object to save address alias
        /// </summary>
        [DataMember(Name = "address_alias", EmitDefaultValue = false)]
        public string AddressAlias { get; set; }
        /// <summary>
        /// String field used in the Address object to save street address 1
        /// </summary>
        [DataMember(Name = "street_address_1", EmitDefaultValue = false)]
        public string StreetAddress1 { get; set; }
        /// <summary>
        /// String field used in the Address object to save street address 2
        /// </summary>
        [DataMember(Name = "street_address_2", EmitDefaultValue = false)]
        public string StreetAddress2 { get; set; }
        /// <summary>
        /// String field used in the Address object to save state
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }
        /// <summary>
        /// String field used in the Address object to save postal code
        /// </summary>
        [DataMember(Name = "postal_code", EmitDefaultValue = false)]
        public string PostalCode { get; set; }
        /// <summary>
        /// String field used in the Address object to save nickname
        /// </summary>
        [DataMember(Name = "nickname", EmitDefaultValue = false)]
        public string Nickname { get; set; }
    }
}
