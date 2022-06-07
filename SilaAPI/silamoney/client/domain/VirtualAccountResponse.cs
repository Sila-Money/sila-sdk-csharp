using Newtonsoft.Json;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class VirtualAccountResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account")]
        public VirtualAccount VirtualAccount { get; set; }
    }
}
