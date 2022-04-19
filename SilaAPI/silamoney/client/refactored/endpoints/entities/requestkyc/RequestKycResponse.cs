using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestKycResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("verification_uuid")]
        public string VerificationUuid { get; private set; }
    }
}