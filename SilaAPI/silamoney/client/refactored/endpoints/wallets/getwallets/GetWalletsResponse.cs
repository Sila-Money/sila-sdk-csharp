using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Cards
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWalletsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; private set; }
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
        [JsonProperty("cards")]
        public List<Card> Cards { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_time_ms")]
        public string ResponseTimeMs { get; set; }
    }
}
