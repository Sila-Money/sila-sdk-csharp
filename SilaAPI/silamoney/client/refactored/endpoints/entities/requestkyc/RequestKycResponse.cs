using Newtonsoft.Json;

namespace SilaAPI.Silamoney.Client.Refactored.Endpoints.Entitiesrequestkyc
{
    public class RequestKycResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("reference")]
        public string Reference { get; private set; }
        [JsonProperty("message")]
        public string Message { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("verification_uuid")]
        public string VerificationUuid { get; private set; }
    }
}