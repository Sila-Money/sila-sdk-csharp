using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.refactored.endpoints.entities.checkpartnerkyc
{
    public class CheckPartnerKycResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("reference")]
        public string Reference { get; private set; }
        [JsonProperty("message")]
        public string Message { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("entity_type")]
        public string EntityType { get; private set; }
        [JsonProperty("verification_status")]
        public string VerificationStatus { get; private set; }
    }
}