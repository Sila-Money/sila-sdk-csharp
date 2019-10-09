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
        /// <summary>
        /// EnumMember values for Country field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CountryEnum
        {
            [EnumMember(Value = "US")]
            US = 1
        }
        /// <summary>
        /// Enum field used in the Address object to select Country
        /// </summary>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public CountryEnum country { get; set; }
        /// <summary>
        /// String field used in the Address object to save city
        /// </summary>
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string city { get; set; }
        /// <summary>
        /// String field used in the Address object to save address alias
        /// </summary>
        [DataMember(Name = "address_alias", EmitDefaultValue = false)]
        public string addressAlias { get; set; }
        /// <summary>
        /// String field used in the Address object to save street address 1
        /// </summary>
        [DataMember(Name = "street_address_1", EmitDefaultValue = false)]
        public string streetAddress1 { get; set; }
        /// <summary>
        /// String field used in the Address object to save street address 2
        /// </summary>
        [DataMember(Name = "street_address_2", EmitDefaultValue = false)]
        public string streetAddress2 { get; set; }
        /// <summary>
        /// String field used in the Address object to save state
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string state { get; set; }
        /// <summary>
        /// String field used in the Address object to save postal code
        /// </summary>
        [DataMember(Name = "postal_code", EmitDefaultValue = false)]
        public string postalCode { get; set; }

        /// <summary>
        /// If user is not null, set user values in the Address object
        /// </summary>
        /// <param name="user"></param>
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
