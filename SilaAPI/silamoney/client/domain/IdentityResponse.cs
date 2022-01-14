using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentityResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("identity")]
        public IdentityData Identity { get; set; }
    }
}
