using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class GetDocumentMsg
    {
        [DataMember(Name = "header")]
        public Header Header { get; }
        [DataMember(Name = "document_id")]
        public string DocumentId { get; }

        public GetDocumentMsg(string authHandle, string userHandle, string documentId)
        {
            Header = new Header(userHandle, authHandle);
            DocumentId = documentId;
        }
    }
}
