using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <sumary>
    ///
    /// </sumary>
    public class DocumentType
    {
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("label")]
        public string Label { get; set; }
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("identity_type")]
        public string IdentityType { get; set; }
    }
}
