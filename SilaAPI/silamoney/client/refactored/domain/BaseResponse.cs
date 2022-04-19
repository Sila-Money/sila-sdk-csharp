using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Object used to store response message.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// String field used in the BaseResponse object to save message 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// String field used in the BaseResponse object to save status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Boolean field used to indicate if the response was successful or not
        /// </summary>
        [JsonProperty("success")]
        public Boolean Success { get; set; }
        /// <summary>
        /// response time ms
        /// </summary>
        [JsonProperty("response_time_ms")]
        public string ResponseTimeMs { get; set; }
        /// <summary>
        /// String field used in the BaseResponse object to save reference
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
