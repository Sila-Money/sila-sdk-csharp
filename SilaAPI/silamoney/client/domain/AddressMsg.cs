using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class AddressMsg : RegistrationDataMsg
    {
        [DataMember(Name = "address_alias", EmitDefaultValue = false)]
        public string AddressAlias { get; }
        [DataMember(Name = "street_address_1", EmitDefaultValue = false)]
        public string StreetAddress1 { get; set; }
        [DataMember(Name = "street_address_2", EmitDefaultValue = false)]
        public string StreetAddress2 { get; set; }
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }
        [DataMember(Name = "postal_code", EmitDefaultValue = false)]
        public string PostalCode { get; set; }
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        public AddressMsg(string authHandle, string userHandle, AddressMessage address) : base(authHandle, userHandle, address.Uuid)
        {
            AddressAlias = address.AddressAlias;
            StreetAddress1 = address.StreetAddress1;
            StreetAddress2 = address.StreetAddress2;
            City = address.City;
            State = address.State;
            PostalCode = address.PostalCode;
            Country = address.Country;
        }
    }
}
