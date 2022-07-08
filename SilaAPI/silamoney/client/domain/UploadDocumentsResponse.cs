using Newtonsoft.Json;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadDocumentsResponse : BaseResponseWithoutReference
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
