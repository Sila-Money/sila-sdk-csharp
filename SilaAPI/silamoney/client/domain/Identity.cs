using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Identity object used in the EntityMsg object
    /// </summary>
    [DataContract]
    public partial class Identity : EntityAudit
    {
        /// <summary>
        /// Enum field used in the Identity object to select identity alias
        /// </summary>
        [DataMember(Name = "identity_alias", EmitDefaultValue = false)]
        public IdentityAlias IdentityAliasOption { get; set; }
        /// <summary>
        /// String field used in the Identity object to save identity value
        /// </summary>
        [DataMember(Name = "identity_value", EmitDefaultValue = false)]
        public string IdentityValue { get; set; }
        /// <summary>
        /// String field used in the Identity object to save identity
        /// </summary>
        [DataMember(Name = "identity", EmitDefaultValue = false)]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// String field used in the Identity object to save identity type
        /// </summary>
        [DataMember(Name = "identity_type", EmitDefaultValue = false)]
        public string IdentityType { get; set; }

        /// <summary>
        /// Identity constructor
        /// </summary>
        /// <param name="user"></param>
        public Identity(User user)
        {
            if (user != null)
            {
                this.IdentityAliasOption = IdentityAlias.SSN;
                this.IdentityValue = user.IdentityValue;
            }
        }

        /// <summary>
        /// Identity constructor
        /// </summary>
        /// <param name="user"></param>
        public Identity(BusinessUser user)
        {
            if (user != null)
            {
                this.IdentityAliasOption = IdentityAlias.EIN;
                this.IdentityValue = user.IdentityValue;
            }
        }

        /// <summary>
        /// Identity constructor.
        /// </summary>
        public Identity(){}
    }
}
