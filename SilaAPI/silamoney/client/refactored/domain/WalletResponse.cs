using Newtonsoft.Json;

namespace Sila.API.Client.Domain
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
