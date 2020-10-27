using Newtonsoft.Json;
using System;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseResponseWithoutReference
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
    }
}
