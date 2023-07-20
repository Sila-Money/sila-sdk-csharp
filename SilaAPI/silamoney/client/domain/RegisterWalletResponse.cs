using Newtonsoft.Json;
using System.Runtime.Serialization;

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
        /// <summary>
        /// bool field used in the Register Wallet Response  object
        /// </summary>
        [DataMember(Name = "statements_enabled")]
        public bool StatementsEnabled { get; set; }
    }
}
