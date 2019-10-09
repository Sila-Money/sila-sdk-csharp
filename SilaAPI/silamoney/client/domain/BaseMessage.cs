using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Parent object used in all the message objects
    /// </summary>
    [DataContract]
    public class BaseMessage
    {
        /// <summary>
        /// Header object field used in the BaseMessage object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header header { get; set; }
        /// <summary>
        /// EnumMember values for Message field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MessageEnum
        {
            [EnumMember(Value = "header_msg")]
            HeaderMsg = 1,
            [EnumMember(Value = "entity_msg")]
            EntityMsg = 2,
            [EnumMember(Value = "get_accounts_msg")]
            GetAccountsMsg = 3,
            [EnumMember(Value = "get_transactions_msg")]
            GetTransactionMsg = 4,
            [EnumMember(Value = "issue_msg")]
            IssueMsg = 5,
            [EnumMember(Value = "link_account_msg")]
            LinkAccountMsg = 6,
            [EnumMember(Value = "redeem_msg")]
            RedeemMsg = 7,
            [EnumMember(Value = "transfer_msg")]
            TransferMsg = 8
        }
        /// <summary>
        /// Enum field used in the BaseMessage object to select message
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public MessageEnum message { get; set; }
    }
}
