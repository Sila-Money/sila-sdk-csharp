using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class Identity
    {
        /// <summary>
        /// EnumMember values for IdentityAlias field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IdentityAlias
        {
            /// <summary>
            /// Value: SSN
            /// </summary>
            [EnumMember(Value = "SSN")]
            SSN = 1,
            /// <summary>
            /// Value EIN
            /// </summary>
            [EnumMember(Value = "EIN")]
            EIN = 2,
            /// <summary>
            /// Value ITIN
            /// </summary>
            [EnumMember(Value = "ITIN")]
            ITIN = 3
        }
    }
}
