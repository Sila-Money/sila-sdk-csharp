using Newtonsoft.Json;

namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckPartnerKycResponse
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
        /// 
        /// </summary>
        [JsonProperty("entity_type")]
        public string EntityType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("verification_status")]
        public string VerificationStatus { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_time_ms")]
        public string ResponseTimeMs { get; set; }
    }
}