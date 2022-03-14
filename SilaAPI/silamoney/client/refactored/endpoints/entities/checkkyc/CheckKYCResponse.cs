using Newtonsoft.Json;
using Sila.API.Client.Domain;
using System.Collections.Generic;

namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckKYCResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>
        ///  String field used in the TransactionResponse object to save error_code
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

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