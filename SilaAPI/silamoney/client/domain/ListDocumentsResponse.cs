using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class ListDocumentsResponse : BaseResponse
    {       
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
