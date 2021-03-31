using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.refactored.domain
{
    /// <summary>
    /// Identity object used in the EntityMsg object
    /// </summary>
    [DataContract]
    public class Identity
    {
        /// <summary>
        /// Enum field used in the Identity object to select identity alias
        /// </summary>
        [DataMember(Name = "identity_alias", EmitDefaultValue = false)]
        public string IdentityAlias { get; set; }
        /// <summary>
        /// String field used in the Identity object to save identity value
        /// </summary>
        [DataMember(Name = "identity_value", EmitDefaultValue = false)]
        public string IdentityValue { get; set; }
    }
}
