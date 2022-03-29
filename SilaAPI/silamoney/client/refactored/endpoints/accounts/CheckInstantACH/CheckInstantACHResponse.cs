using Newtonsoft.Json;

namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckInstantACHResponse
    {
        /// <summary>
        /// String field used in the BaseResponse object to save success
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; private set; }

        /// <summary>
        /// String field used in the BaseResponse object to save message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; private set; }

        /// <summary>
        /// String field used in the BaseResponse object to save status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>
        /// String field used in the BaseResponse object to save reference
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; private set; }

        /// <summary>
        /// String field used in the BaseResponse object to save qualification_details
        /// </summary>
        [JsonProperty("qualification_details")]
        public QualificationDetails QualificationDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_time_ms")]
        public string ResponseTimeMs { get; set; }
    }
}