using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public AddressData Address { get; set; }
    }
}
