using Newtonsoft.Json;
using Sila.API.Client.Domain;
namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckPartnerKycResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity_type")]
        public string EntityType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("verification_status")]
        public string VerificationStatus { get; private set; }
    }
}