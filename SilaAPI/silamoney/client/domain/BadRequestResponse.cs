using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class BadRequestResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("validation_details")]
        public dynamic ValidationDetails { get; set; }
    }
}
