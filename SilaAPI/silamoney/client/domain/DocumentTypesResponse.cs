using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    public class DocumentTypesResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("document_types")]
        public List<DocumentType> DocumentTypes { get; set; }
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
