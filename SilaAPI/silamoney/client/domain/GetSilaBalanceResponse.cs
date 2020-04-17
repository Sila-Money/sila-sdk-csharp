using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetSilaBalanceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sila_balance")]
        public decimal SilaBalance { get; set; }
    }
}
