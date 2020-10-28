using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class EmailMsg : RegistrationDataMsg
    {
        [DataMember(Name = "email")]
        public string Email { get; }
        public EmailMsg(string authHandle, string userHandle, string email, string uuid = null) : base(authHandle, userHandle, uuid)
        {
            Email = email;
        }
    }
}
