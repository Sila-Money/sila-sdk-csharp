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
            [EnumMember(Value = "queued")]
            Queued,
            /// <summary>
            /// Value: complete
            /// </summary>
            [EnumMember(Value = "pending")]
            Pending,
            /// <summary>
            /// Value: successful
            /// </summary>
            [EnumMember(Value = "failed")]
            Failed,
            /// <summary>
            /// Value: failed
            /// </summary>
            [EnumMember(Value = "success")]
            Success,
            /// <summary>
            /// Value: failed
            /// </summary>
            [EnumMember(Value = "rollback")]
            Rollback,
            /// <summary>
            /// Value: failed
            /// </summary>
            [EnumMember(Value = "review")]
            Review,
            /// <summary>
            /// Value: failed
            /// </summary>
            [EnumMember(Value = "pending_confirmation")]
            PendingConfirmation,
        }
    }
}
