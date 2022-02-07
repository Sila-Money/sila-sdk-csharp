using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class SilaBalanceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("silaBalance")]
        public decimal? SilaBalance { get; set; }
    }
}
