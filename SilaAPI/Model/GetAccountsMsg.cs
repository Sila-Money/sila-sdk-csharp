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
    public partial class GetAccountsMsg
    {
        
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MessageEnum
        {
            [EnumMember(Value = "get_accounts_msg")]
            Msg = 1
        }

        [DataMember(Name="message", EmitDefaultValue=false)]
        public MessageEnum message { get; set; }

        public GetAccountsMsg(Header header = default(Header))
        {
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for GetAccountsMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.message = MessageEnum.Msg;
        }
        
        [DataMember(Name="header", EmitDefaultValue=false)]
        public Header header { get; set; }
    }
}
