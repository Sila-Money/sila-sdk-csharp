using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class PlaidSameDayAuthResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("public_token")]
        public string PublicToken { get; set; }
    }
}
