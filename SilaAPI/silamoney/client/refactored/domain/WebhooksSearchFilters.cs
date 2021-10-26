using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// SearchFilters object used in the GetWebhooks method
    /// </summary>
    public class WebhooksSearchFilters
    {
        /// <summary>
        /// </summary>       
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// </summary>       
        [JsonProperty("delivered")]
        public bool? Delivered { get; set; }
        /// <summary>
        /// 
        /// </summary>        
        [JsonProperty("sort_ascending")]
        public bool? SortAscending { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; set; }
        /// <summary>
        /// 
        /// </summary>        
        [JsonProperty("endpoint_name")]
        public string EndpointName { get; set; }
        /// <summary>
        /// 
        /// </summary>        
        [JsonProperty("user_handle")]
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>      
        [JsonProperty("start_epoch")]
        public int? StartEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>        
        [JsonProperty("end_epoch")]
        public int? EndEpoch { get; set; }
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
