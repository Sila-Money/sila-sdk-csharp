using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class PlaidLinkTokenResult : BaseResponse
    {  
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("link_token")]
        public string LinkToken { get; set; }
    }
}
