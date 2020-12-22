using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class WalletResponse : Wallet
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("default")]
        public bool Default { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("frozen")]
        public bool Frozen { get; set; }
    }
}
