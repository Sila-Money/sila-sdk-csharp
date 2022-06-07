using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Webhooks
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWebhooksResponse : BaseResponse
    {
        /// <summary>
        /// Integer field used in the GetWebhooksResponse to save page
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }
        /// <summary>
        /// Integer field used in the GetWebhooksResponse to save returned count
        /// </summary>
        [JsonProperty("returned_count")]
        public int ReturnedCount { get; set; }
        /// <summary>
        /// Integer field used in the GetWebhooksResponse to save total count
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        /// <summary>
        /// List of Webhooks objects used in the GetWebhooks to save webhooks
        /// </summary>
        [JsonProperty("webhooks")]
        public List<Webhook> Webhooks { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}

