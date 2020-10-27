using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class IdentityMsg : RegistrationDataMsg
    {
        [DataMember(Name = "identity_alias")]
        public string IdentityAlias { get; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "identity_value")]
        public string IdentityValue { get; }
        public IdentityMsg(string authHandle, string userHandle, IdentityMessage identity) : base(authHandle, userHandle, identity.Uuid)
        {
            IdentityAlias = identity.IdentityAlias;
            IdentityValue = identity.IdentityValue;
        }
    }
}
