using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <sumary>
    ///
    /// </sumary>
    public class DocumentTypesResponse : BaseResponse
    {
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
