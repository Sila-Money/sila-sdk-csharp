using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.Model
{
    [DataContract]
    public partial class Address
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CountryEnum
        {
            [EnumMember(Value = "US")]
            US = 1
        }
        public Address(CountryEnum country = default(CountryEnum), string city = default(string), string addressAlias = default(string), string streetAddress1 = default(string), string streetAddress2 = default(string), string state = default(string), string postalCode = default(string))
        {
            this.country = country;
            if (city == null)
            {
                throw new InvalidDataException("city is a required property for Address and cannot be null");
            }
            else
            {
                this.city = city;
            }
            if (addressAlias == null)
            {
                throw new InvalidDataException("addressAlias is a required property for Address and cannot be null");
            }
            else
            {
                this.addressAlias = addressAlias;
            }
            if (streetAddress1 == null)
            {
                throw new InvalidDataException("streetAddress1 is a required property for Address and cannot be null");
            }
            else
            {
                this.streetAddress1 = streetAddress1;
            }
            if (state == null)
            {
                throw new InvalidDataException("state is a required property for Address and cannot be null");
            }
            else
            {
                this.state = state;
            }
            if (postalCode == null)
            {
                throw new InvalidDataException("postalCode is a required property for Address and cannot be null");
            }
            else
            {
                if (postalCode.Length != 5 || postalCode.Length != 10)
                {
                    throw new InvalidDataException("postalCode must be the 5-digit ZIP code or ZIP+4 code.");
                }
                else
                {
                    this.postalCode = postalCode;
                }
            }
            this.streetAddress2 = streetAddress2;
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
    }
}
