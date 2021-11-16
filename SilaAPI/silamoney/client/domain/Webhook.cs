using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Webhook object used in the get_webhooks endpoint response
    /// </summary>
    public class Webhook
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_epoch")]
        public int? CreatedEpoch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last_update_epoch")]
        public long? LastUpdateEpoch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("next_attempt_epoch")]
        public long? NextAttemptEpoch { get; set; }
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
        [JsonProperty("endpoint_url")]
        public string EndpointUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("delivered")]
        public bool? Delivered { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("details")]
        public Detail Details { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("attempts")]
        public int? Attempts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("responses")]
        public List<Responses> Responses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("processing")]
        public bool? Processing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_handle")]
        public string UserHandle { get; set; }
    }
}
