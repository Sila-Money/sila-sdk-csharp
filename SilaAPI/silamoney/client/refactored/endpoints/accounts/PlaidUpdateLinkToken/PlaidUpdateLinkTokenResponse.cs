using Newtonsoft.Json;
using Sila.API.Client.Domain;
namespace Sila.API.Client.Accounts
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