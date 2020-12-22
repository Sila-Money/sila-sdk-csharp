using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class PhoneMsg : RegistrationDataMsg
    {
        [DataMember(Name = "phone")]
        public string Phone { get; }
        [DataMember(Name = "sms_opt_in", EmitDefaultValue = false)]
        public bool? SmsOptIn { get; }

        public PhoneMsg(string authHandle, string userHandle, string phone, string uuid = null, bool? smsOptIn = null) : base(authHandle, userHandle, uuid)
        {
            Phone = phone;
            SmsOptIn = smsOptIn;
        }
    }
}
