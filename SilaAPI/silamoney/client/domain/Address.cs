using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Address object used in the entity_msg object
    /// </summary>
    [DataContract]
    public partial class Address
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CountryEnum
        {
            [EnumMember(Value = "US")]
            US = 1
        }
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public CountryEnum country { get; set; }
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string city { get; set; }
        [DataMember(Name = "address_alias", EmitDefaultValue = false)]
        public string addressAlias { get; set; }
        [DataMember(Name = "street_address_1", EmitDefaultValue = false)]
        public string streetAddress1 { get; set; }
        [DataMember(Name = "street_address_2", EmitDefaultValue = false)]
        public string streetAddress2 { get; set; }
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string state { get; set; }
        [DataMember(Name = "postal_code", EmitDefaultValue = false)]
        public string postalCode { get; set; }

        public Address(User user)
        {
            if (user != null)
            {
                this.addressAlias = "";
                this.streetAddress1 = user.streetAddress1;
                this.streetAddress2 = user.streetAddress2;
                this.city = user.city;
                this.state = user.state;
                this.country = Address.CountryEnum.US;
                this.postalCode = user.portalCode;
            }
        }
    }
}
