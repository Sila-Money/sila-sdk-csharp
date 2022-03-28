using Sila.API.Client.Domain;

namespace Sila.API.Client.UploadDocument
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
        public string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Filename { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Hash { get; }
        /// <summary>
        /// 
        /// </summary>
        public string MimeType { get; }
        /// <summary>
        /// 
        /// </summary>
        public string DocumentType { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; }


    }
}