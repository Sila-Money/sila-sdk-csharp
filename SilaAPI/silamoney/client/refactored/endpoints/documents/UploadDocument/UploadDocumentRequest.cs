using System.Collections.Generic;
namespace Sila.API.Client.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadDocumentRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Sila.API.Client.Domain.UploadDocument> UploadDocument { get; }
      
    }
}