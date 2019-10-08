﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
namespace SilaAPI.com.silamoney.client.domain
{
    [DataContract]
    public class BaseMessage
    {
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header header { get; set; }
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

        [DataMember(Name = "message", EmitDefaultValue = false)]
        public MessageEnum message { get; set; }
    }
}
