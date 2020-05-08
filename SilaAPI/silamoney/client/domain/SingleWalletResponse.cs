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
        public SingleWallet Wallet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("is_whitelisted")]
        public bool IsWhitelisted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sila_balance")]
        public decimal SilaBalance { get; set; }
    }
}
