using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class SearchFilters
    {
        /// <summary>
        /// EnumMember values for Statuses field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Statuses
        {
            /// <summary>
            /// Value: pending
            /// </summary>
            [EnumMember(Value = "pending")]
            Pending = 1,
            /// <summary>
            /// Value: complete
            /// </summary>
            [EnumMember(Value = "complete")]
            Complete = 2,
            /// <summary>
            /// Value: successful
            /// </summary>
            [EnumMember(Value = "successful")]
            Successful = 3,
            /// <summary>
            /// Value: failed
            /// </summary>
            [EnumMember(Value = "failed")]
            Failed = 4
        }
    }
}
