using Newtonsoft.Json;

namespace Sila.API.Client.Entities
{
    public class RegisterResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("reference")]
        public string Reference { get; private set; }
        [JsonProperty("message")]
        public string Message { get; private set; }
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