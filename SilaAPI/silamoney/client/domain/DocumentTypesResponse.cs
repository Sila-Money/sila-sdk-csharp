using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <sumary>
    ///
    /// </sumary>
    public class DocumentTypesResponse
    {
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("success")]
        public bool Success { get; set; }
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("document_types")]
        public List<DocumentType> DocumentTypes { get; set; }
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
