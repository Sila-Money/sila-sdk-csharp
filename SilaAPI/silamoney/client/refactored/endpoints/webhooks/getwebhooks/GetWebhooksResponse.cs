﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.GetWebhooks
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWebhooksResponse
    {
        /// <summary>
        /// Boolean field used in the GetWebhooksResponse to save success value
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
        /// <summary>
        /// String field used to indicate if the api call was successful
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
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

