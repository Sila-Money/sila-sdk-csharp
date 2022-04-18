using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class PlaidUpdateLinkTokenResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("link_token")]
        public string LinkToken { get; private set; }
    }
}