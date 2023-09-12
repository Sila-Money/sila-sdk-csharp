using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class CkoTestingTokenResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
