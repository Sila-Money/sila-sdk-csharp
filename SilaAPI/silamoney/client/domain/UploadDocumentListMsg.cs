using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class UploadDocumentListMsg
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "header")]
        public Header Header { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "file_metadata")]
        public object FileMetadata { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authHandle"></param>
        /// <param name="userHandle"></param>
        /// <param name="fileMetadata"></param>
        public UploadDocumentListMsg(string authHandle, string userHandle, object fileMetadata)
        {
            Header = new Header(userHandle, authHandle);
            FileMetadata = fileMetadata;
        }

    }

}
