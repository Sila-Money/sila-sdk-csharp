using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetSilaBalanceResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
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
