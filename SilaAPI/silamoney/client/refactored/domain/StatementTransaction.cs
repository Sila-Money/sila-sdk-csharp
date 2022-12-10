using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class StatementTransaction
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("settled_date")]
        public string SettledDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("running_balance")]
        public string RunningBalance { get; set; }
    }
}
