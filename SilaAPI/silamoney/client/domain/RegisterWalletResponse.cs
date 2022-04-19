using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterWalletResponse : BaseResponse
    {
        /// <summary>
        /// String field used to save wallet_nickname
        /// </summary>
        [JsonProperty("wallet_nickname")]
        public string WalletNickname { get; set; }
    }
}
