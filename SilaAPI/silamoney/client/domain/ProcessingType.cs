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
        /// Standard ACH
        /// </summary>
        [EnumMember(Value = "STANDARD_ACH")]
        Standard = 1,
        /// <summary>
        /// Same day ACH
        /// </summary>
        [EnumMember(Value = "SAME_DAY_ACH")]
        Sameday = 2,
        /// <summary>
        /// Instant ACH
        /// </summary>
        [EnumMember(Value = "INSTANT_ACH")]
        Instant,
        /// <summary>
        /// CARD
        /// </summary>
        [EnumMember(Value = "CARD")]
        Card
    }
}
