using Newtonsoft.Json;

namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; private set; }
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
        ///  String field used in the RegisterResponse object to save BusinessUuid
        /// </summary>
        /// <value>BusinessUuid</value>
        [JsonProperty("business_uuid")]
        public string BusinessUuid { get; private set; }
    }
}