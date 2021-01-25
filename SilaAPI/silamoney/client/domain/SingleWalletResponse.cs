using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class SingleWalletResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WalletResponse Wallet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("is_whitelisted")]
        public bool IsWhitelisted { get; set; }

        [JsonProperty("sila_balance")]
        internal decimal Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SilaBalance { get { return decimal.ToInt32(Balance); } }
    }
}
