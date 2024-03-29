using Newtonsoft.Json;
using Sila.API.Client.Domain;
using System.Collections.Generic;

namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckKYCResponse : BaseResponse
    {
        /// <summary>
        /// Indicates the type of entity being verified
        /// </summary>
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }
        /// <summary>
        /// Indicates the verification status of the entity
        /// </summary>
        [JsonProperty("verification_status")]
        public string VerificationStatus { get; set; }
        /// <summary>
        /// An array of the verification tries results
        /// </summary>
        [JsonProperty("verification_history")]
        public List<VerificationResult> VerificationHistory { get; set; }
        /// <summary>
        /// An array of valid kyc levels for the entity
        /// </summary>
        [JsonProperty("valid_kyc_levels")]
        public List<string> ValidKYCLevels { get; set; }
    }
}