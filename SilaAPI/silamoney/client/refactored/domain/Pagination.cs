using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Object used in the GetEntitiesResponse object.
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("returned_count")]
        public int ReturnedCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}