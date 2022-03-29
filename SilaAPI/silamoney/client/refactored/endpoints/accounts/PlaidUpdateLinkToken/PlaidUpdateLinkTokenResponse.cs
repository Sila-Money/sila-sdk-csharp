using Newtonsoft.Json;

namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class PlaidUpdateLinkTokenResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; private set; }

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
        [JsonProperty("link_token")]
        public string LinkToken { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_time_ms")]
        public string ResponseTimeMs { get; set; }
    }
}