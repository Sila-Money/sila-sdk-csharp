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

        [JsonProperty("sila_balance")]
        internal decimal Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SilaBalance { get { return decimal.ToInt32(Balance); } }
    }
}
