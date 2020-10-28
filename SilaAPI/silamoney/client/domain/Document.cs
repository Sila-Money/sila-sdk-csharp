using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Document
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_handle")]
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("document_id")]
        public string DocumentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("filename")]
        public string Filename { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created")]
        public string Created { get; set; }
    }
}
