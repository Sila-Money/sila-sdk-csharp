using Newtonsoft.Json;

namespace Sila.API.Client.Accounts
{
    public class PlaidUpdateLinkTokenResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("message")]
        public string Message { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("link_token")]
        public string LinkToken { get; private set; }
    }
}