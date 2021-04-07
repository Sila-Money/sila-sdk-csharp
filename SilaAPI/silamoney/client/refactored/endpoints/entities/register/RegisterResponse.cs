using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.refactored.endpoints.entities.register
{
    public class RegisterResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("reference")]
        public string Reference { get; private set; }
        [JsonProperty("message")]
        public string Message { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
    }
}