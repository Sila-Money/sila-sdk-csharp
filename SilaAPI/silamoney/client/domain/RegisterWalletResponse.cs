using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterWalletResponse
    {
        /// <summary>
        /// String field used to save reference
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// String field used to save message 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Boolean field used to save success
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// String field used to save wallet_nickname
        /// </summary>
        [JsonProperty("wallet_nickname")]
        public string WalletNickname { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
