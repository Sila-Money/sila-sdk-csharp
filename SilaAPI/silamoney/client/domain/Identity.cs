using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    public partial class Identity
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IdentityAliasEnum
        {
            [EnumMember(Value = "SSN")]
            SSN = 1,
            [EnumMember(Value = "EIN")]
            EIN = 2,
            [EnumMember(Value = "ITIN")]
            ITIN = 3
        }

        [DataMember(Name = "identity_alias", EmitDefaultValue = false)]
        public IdentityAliasEnum identityAlias { get; set; }
        [DataMember(Name = "identity_value", EmitDefaultValue = false)]
        public string identityValue { get; set; }

        public Identity(User user)
        {
            if (user != null)
            {
                this.identityAlias = IdentityAliasEnum.SSN;
                this.identityValue = user.identityValue;
            }
        }
    }
}
