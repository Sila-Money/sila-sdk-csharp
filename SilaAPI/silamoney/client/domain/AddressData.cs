using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressData : RegistrationDataBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("street_address_1")]
        public string StreetAddress1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("street_address_2")]
        public string StreetAddress2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
    }
}
