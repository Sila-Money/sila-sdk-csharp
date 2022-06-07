using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Wallets
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
