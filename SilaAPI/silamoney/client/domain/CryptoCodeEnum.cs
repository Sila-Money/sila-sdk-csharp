using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class CryptoEntry
    {
        /// <summary>
        /// EnumMember values for CryptoCode field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CryptoCode
        {
            /// <summary>
            /// Value: ETH
            /// </summary>
            [EnumMember(Value = "ETH")]
            ETH = 1
        }
    }
}
