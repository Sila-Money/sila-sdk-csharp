using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class SearchFilters
    {
        /// <summary>
        /// EnumMember values for Transaction types field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionTypes
        {
            /// <summary>
            /// Value: issue
            /// </summary>
            [EnumMember(Value = "issue")]
            Issue = 1,
            /// <summary>
            /// Value: redeem
            /// </summary>
            [EnumMember(Value = "redeem")]
            Redeem = 2,
            /// <summary>
            /// Value: transfer
            /// </summary>
            [EnumMember(Value = "transfer")]
            Transfer = 3
        }
    }
}
