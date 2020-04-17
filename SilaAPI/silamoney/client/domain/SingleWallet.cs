using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class SingleWallet : Wallet
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("default")]
        public bool Default { get; set; }
    }
}
