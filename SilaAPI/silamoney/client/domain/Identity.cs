using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Identity object used in the EntityMsg object
    /// </summary>
    [DataContract]
    public partial class Identity
    {
        /// <summary>
        /// EnumMember values for IdentityAlias field
        /// </summary>
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

        /// <summary>
        /// Enum field used in the Identity object to select identity alias
        /// </summary>
        [DataMember(Name = "identity_alias", EmitDefaultValue = false)]
        public IdentityAliasEnum identityAlias { get; set; }
        /// <summary>
        /// String field used in the Identity object to save identity value
        /// </summary>
        [DataMember(Name = "identity_value", EmitDefaultValue = false)]
        public string identityValue { get; set; }

        /// <summary>
        /// Identity constructor
        /// </summary>
        /// <param name="user"></param>
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
