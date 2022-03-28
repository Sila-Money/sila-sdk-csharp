using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class DocumentMsg
    {
        [DataMember(Name = "header")]
        public Header Header { get; }
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; }
        [DataMember(Name = "filename")]
        public string Filename { get; }
        [DataMember(Name = "hash")]
        public string Hash { get; }
        [DataMember(Name = "mime_type")]
        public string MimeType { get; }
        [DataMember(Name = "document_type")]
        public string DocumentType { get; }

        [DataMember(Name = "identity_type")]
        public string IdentityType { get; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; }

        public DocumentMsg(string authHandle, string userHandle, string filename, string hash, string mimeType, string documentType, string identityType, string name, string description)
        {
            Header = new Header(userHandle, authHandle);
            Name = name;
            Filename = filename;
            Hash = hash;
            MimeType = mimeType;
            DocumentType = documentType;
            IdentityType = identityType;
            Description = description;
        }

        public DocumentMsg(string authHandle, string userHandle, string filename, string hash, string mimeType, string documentType, string name, string description)
        {
            Header = new Header(userHandle, authHandle);
            Name = name;
            Filename = filename;
            Hash = hash;
            MimeType = mimeType;
            DocumentType = documentType;
            Description = description;
        }
    }
}
