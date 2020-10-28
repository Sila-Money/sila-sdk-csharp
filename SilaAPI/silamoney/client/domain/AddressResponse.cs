using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressResponse : BaseResponseWithoutReference
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public AddressData Address { get; set; }
    }
}
