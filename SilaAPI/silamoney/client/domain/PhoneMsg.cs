using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class PhoneMsg : RegistrationDataMsg
    {
        [DataMember(Name = "phone")]
        public string Phone { get; }

        public PhoneMsg(string authHandle, string userHandle, string phone, string uuid = null) : base(authHandle, userHandle, uuid)
        {
            Phone = phone;
        }
    }
}
