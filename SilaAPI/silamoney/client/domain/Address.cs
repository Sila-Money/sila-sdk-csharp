using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        public enum CountryE
        {
            /// <summary>
            /// Value: US
            /// </summary>
            [EnumMember(Value = "US")]
            US = 1
        }
        /// <summary>
        /// Enum field used in the Address object to select Country
        /// </summary>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public CountryE Country { get; set; }
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
        /// If user is not null, set user values in the Address object
        /// </summary>
        /// <param name="user"></param>
        public Address(User user)
        {
            if (user != null)
            {
                this.AddressAlias = "";
                this.StreetAddress1 = user.StreetAddress1;
                this.StreetAddress2 = user.StreetAddress2;
                this.City = user.City;
                this.State = user.State;
                this.Country = Address.CountryE.US;
                this.PostalCode = user.PostalCode;
            }
        }
    }
}
