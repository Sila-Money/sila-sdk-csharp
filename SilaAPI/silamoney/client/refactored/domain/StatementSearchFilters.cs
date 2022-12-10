using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class StatementSearchFilters
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("start_month")]
        public string StartMonth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("end_month")]
        public string EndMonth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("month")]
        public string Month { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
    }
}



