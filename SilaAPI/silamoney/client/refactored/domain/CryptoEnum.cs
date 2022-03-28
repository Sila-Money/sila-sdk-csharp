using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class CryptoEnum
    {
        /// <summary>
        /// EnumMember values for CryptoOption field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Crypto
        {
            /// <summary>
            /// Value: ETH
            /// </summary>
            [EnumMember(Value = "ETH")]
            ETH = 1
        }
    }
}
