using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class Entity
    {
        /// <summary>
        /// EnumMember values for Relationship field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Relationship
        {
            /// <summary>
            /// Value: organization
            /// </summary>
            [EnumMember(Value = "organization")]
            Organization = 1,
            /// <summary>
            /// Value: developer
            /// </summary>
            [EnumMember(Value = "developer")]
            Developer = 2,
            /// <summary>
            /// Value: user
            /// </summary>
            [EnumMember(Value = "user")]
            User = 3,
            /// <summary>
            /// Value: vendor
            /// </summary>
            [EnumMember(Value = "vendor")]
            Vendor = 4
        }
    }
}
