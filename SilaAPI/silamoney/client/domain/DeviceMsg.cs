using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class DeviceMsg
    {
        [DataMember(Name = "header")]
        public Header Header { get; }
        [DataMember(Name = "device_fingerprint", EmitDefaultValue = false)]
        public string DeviceFingerprint { get; }

        [DataMember(Name = "session_identifier", EmitDefaultValue = false)]
        public string SessionIdentifier { get; }

        internal DeviceMsg(string authHandle, string userHandle, string deviceFingerprint, string sessionIdentifier)
        {
            Header = new Header(userHandle, authHandle);
            DeviceFingerprint = deviceFingerprint;
            SessionIdentifier = sessionIdentifier;
        }
    }
}
