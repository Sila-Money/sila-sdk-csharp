using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{
    public partial class BaseMessage
    {
        /// <summary>
        /// EnumMember values for Message field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Message
        {
            /// <summary>
            /// Value: header_msg
            /// </summary>
            [EnumMember(Value = "header_msg")]
            HeaderMsg = 1,
            /// <summary>
            /// Value: entity_msg
            /// </summary>
            [EnumMember(Value = "entity_msg")]
            EntityMsg = 2,
            /// <summary>
            /// Value: get_accounts_msg
            /// </summary>
            [EnumMember(Value = "get_accounts_msg")]
            GetAccountsMsg = 3,
            /// <summary>
            /// Value: get_transaction_msg
            /// </summary>
            [EnumMember(Value = "get_transactions_msg")]
            GetTransactionMsg = 4,
            /// <summary>
            /// Value: issue_msg
            /// </summary>
            [EnumMember(Value = "issue_msg")]
            IssueMsg = 5,
            /// <summary>
            /// Value: link_account_msg
            /// </summary>
            [EnumMember(Value = "link_account_msg")]
            LinkAccountMsg = 6,
            /// <summary>
            /// Value: redeem_msg
            /// </summary>
            [EnumMember(Value = "redeem_msg")]
            RedeemMsg = 7,
            /// <summary>
            /// Value: transfer_msg
            /// </summary>
            [EnumMember(Value = "transfer_msg")]
            TransferMsg = 8
        }
    }
}
