using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class DeleteRegistrationMsg
    {
        [DataMember(Name = "header")]
        public Header Header { get; }
        [DataMember(Name = "uuid")]
        public string Uuid { get; }

        public DeleteRegistrationMsg(string authHandle, string userHandle, string uuid)
        {
            Header = new Header(userHandle, authHandle);
            Uuid = uuid;
        }
    }
}
