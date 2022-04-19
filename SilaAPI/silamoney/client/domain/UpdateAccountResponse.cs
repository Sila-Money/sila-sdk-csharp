using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAccountResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account")]
        public Account Account { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("changes")]
        public List<Change> Changes { get; private set; }
    }
}