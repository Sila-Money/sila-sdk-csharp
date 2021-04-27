using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestKYCResponse : BaseResponse {
        /// <summary>
        /// 
        /// </summary> 
        [JsonProperty("verification_uuid")]
        public string VerificationUuid { get; set; }
    }
}