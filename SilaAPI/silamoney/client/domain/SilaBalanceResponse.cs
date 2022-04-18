using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class SilaBalanceResponse: BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("silaBalance")]
        public decimal? SilaBalance { get; set; }
    }
}
