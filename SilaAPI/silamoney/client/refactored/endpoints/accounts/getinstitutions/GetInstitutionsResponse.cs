using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class GetInstitutionsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("institutions")]
        public List<Institution> Institutions { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("returned_count")]
        public int ReturnedCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_time_ms")]
        public string ResponseTimeMs { get; set; }
    }
}