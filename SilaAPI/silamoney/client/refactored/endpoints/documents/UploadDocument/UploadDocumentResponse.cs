using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.UploadDocument
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadDocumentResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("document_id")]
        public string DocumentId { get; set; }
    }
}
