using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetVirtualAccountResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account")]
        public VirtualAccounts VirtualAccount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public VirtualAccountBalance Balance { get; set; }

    }
}
