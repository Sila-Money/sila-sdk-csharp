using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to display uuid, name and label in different response objects
    /// </summary>
    public class BusinessInformation
    {
        /// <summary>
        /// Uuid of business information
        /// </summary>
        /// <value>uuid</value>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// Name of business information
        /// </summary>
        /// <value>name</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Label of business information
        /// </summary>
        /// <value>label</value>
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}