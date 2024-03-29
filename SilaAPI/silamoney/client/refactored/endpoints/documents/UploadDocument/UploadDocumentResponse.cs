﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Documents
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
        public object DocumentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("unsuccessful_uploads")]
        public object UnsuccessfulUploads { get; set; }

    }

}
