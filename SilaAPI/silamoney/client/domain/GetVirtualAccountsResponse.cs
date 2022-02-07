using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetVirtualAccountsResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_accounts")]
        public List<VirtualAccounts> VirtualAccounts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

    }
}
