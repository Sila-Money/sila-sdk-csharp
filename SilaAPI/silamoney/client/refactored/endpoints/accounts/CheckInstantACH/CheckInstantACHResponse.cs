using Newtonsoft.Json;

namespace SilaAPI.Silamoney.Client.Refactored.Endpoints.Accounts.CheckInstantACH
{
    public class CheckInstantACHResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("message")]
        public string Message { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("reference")]
        public string Reference { get; private set; }
    }
}