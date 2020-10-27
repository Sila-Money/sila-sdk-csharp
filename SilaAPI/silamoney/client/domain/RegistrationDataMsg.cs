using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class RegistrationDataMsg
    {
        [DataMember(Name = "header")]
        public Header Header { get; }
        [DataMember(Name = "uuid", EmitDefaultValue = false)]
        public string Uuid { get; }

        public RegistrationDataMsg(string authHandle, string userHandle, string uuid = null)
        {
            Header = new Header(userHandle, authHandle);
            Uuid = uuid;
        }
    }
}
