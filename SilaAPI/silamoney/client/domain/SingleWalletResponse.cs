using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class SingleWalletResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public WalletResponse Wallet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("is_whitelisted")]
        public bool IsWhitelisted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sila_balance")]
        internal decimal Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SilaBalance { get { return decimal.ToInt32(Balance); } }
    }
}
