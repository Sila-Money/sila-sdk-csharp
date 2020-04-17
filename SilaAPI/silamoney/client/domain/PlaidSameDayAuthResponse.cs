using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class PlaidSameDayAuthResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("public_token")]
        public string PublicToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
