using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace SilaAPI.Model
{
    /// <summary>
    /// RedeemMsg
    /// </summary>
    [DataContract]
    public partial class RedeemMsg 
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MessageEnum
        {
            [EnumMember(Value = "redeem_msg")]
            Msg = 1
        }

        [DataMember(Name="message", EmitDefaultValue=false)]
        public MessageEnum message { get; set; }

        public RedeemMsg(decimal? amount = default(decimal?), string accountName = default(string), Header header = default(Header))
        {
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for RedeemMsg and cannot be null");
            }
            else
            {
                this.amount = amount;
            }
            if (accountName == null)
            {
                throw new InvalidDataException("accountName is a required property for RedeemMsg and cannot be null");
            }
            else
            {
                this.accountName = accountName;
            }
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for RedeemMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.message = MessageEnum.Msg;
        }

        [DataMember(Name="amount", EmitDefaultValue=false)]
        public decimal? amount { get; set; }

        [DataMember(Name="account_name", EmitDefaultValue=false)]
        public string accountName { get; set; }

        [DataMember(Name="header", EmitDefaultValue=false)]
        public Header header { get; set; }
    }
}
