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
    [DataContract]
    public partial class LinkAccountMsg
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MessageEnum
        {
            [EnumMember(Value = "link_account_msg")]
            Msg = 1
        }

        [DataMember(Name="message", EmitDefaultValue=false)]
        public MessageEnum message { get; set; }

        public LinkAccountMsg(string publicToken = default(string), string accountName = default(string), Header header = default(Header), string selectedAccountId = default(string), MessageEnum message = default(MessageEnum))
        {
            if (publicToken == null)
            {
                throw new InvalidDataException("publicToken is a required property for LinkAccountMsg and cannot be null");
            }
            else
            {
                this.publicToken = publicToken;
            }
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for LinkAccountMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.accountName = accountName;
            this.selectedAccountId = selectedAccountId;
            this.message = MessageEnum.Msg;
        }
        
        [DataMember(Name="public_token", EmitDefaultValue=false)]
        public string publicToken { get; set; }

        [DataMember(Name="account_name", EmitDefaultValue=false)]
        public string accountName { get; set; }

        [DataMember(Name="header", EmitDefaultValue=false)]
        public Header header { get; set; }

        [DataMember(Name="selected_account_id", EmitDefaultValue=false)]
        public string selectedAccountId { get; set; }
    }
}
