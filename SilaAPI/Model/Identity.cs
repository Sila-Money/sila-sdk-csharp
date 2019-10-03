using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SilaAPI.Model
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
        
        [DataMember(Name="identity_alias", EmitDefaultValue=false)]
        public IdentityAliasEnum identityAlias { get; set; }

        public Identity(IdentityAliasEnum identityAlias = default(IdentityAliasEnum), string identityValue = default(string))
        {
            if (identityAlias == null)
            {
                throw new InvalidDataException("identityAlias is a required property for Identity and cannot be null");
            }
            else
            {
                this.identityAlias = identityAlias;
            }
            if (identityValue == null)
            {
                throw new InvalidDataException("identityValue is a required property for Identity and cannot be null");
            }
            else
            {
                this.identityValue = identityValue;
            }
        }
        
        [DataMember(Name="identity_value", EmitDefaultValue=false)]
        public string identityValue { get; set; }
    }
}
