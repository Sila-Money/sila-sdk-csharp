using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// EnumMember values for processing_type field
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProcessingType
    {
        /// <summary>
        /// Value: header_msg
        /// </summary>
        [EnumMember(Value = "STANDARD_ACH")]
        Standard = 1,
        /// <summary>
        /// Value: header_msg
        /// </summary>
        [EnumMember(Value = "SAME_DAY_ACH")]
        Sameday = 2
    }
}
