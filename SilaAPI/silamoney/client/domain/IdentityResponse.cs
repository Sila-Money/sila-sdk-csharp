using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentityResponse : BaseResponseWithoutReference
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("identity")]
        public IdentityData Identity { get; set; }
    }
}
