using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Accounts
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