using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class Header
    {
        /// <summary>
        /// EnumMember values for Version field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum VersionEnum
        {
            /// <summary>
            /// Value: 0.2
            /// </summary>
            [EnumMember(Value = "0.2")]
            _02 = 1,
            /// <summary>
            /// Value: v0.2
            /// </summary>
            [EnumMember(Value = "v0.2")]
            V02 = 2
        }
    }
}
