using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}