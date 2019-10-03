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
    public partial class TransferMsg 
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MessageEnum
        {
            [EnumMember(Value = "transfer_msg")]
            Msg = 1
        }

        [DataMember(Name="message", EmitDefaultValue=false)]
        public MessageEnum message { get; set; }

        public TransferMsg(decimal? amount = default(decimal?), string destination = default(string), Header header = default(Header))
        {
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for TransferMsg and cannot be null");
            }
            else
            {
                this.amount = amount;
            }
            if (destination == null)
            {
                throw new InvalidDataException("destination is a required property for TransferMsg and cannot be null");
            }
            else
            {
                this.destination = destination;
            }
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for TransferMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.message = MessageEnum.Msg;
        }
        
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public decimal? amount { get; set; }

        [DataMember(Name="destination", EmitDefaultValue=false)]
        public string destination { get; set; }

        [DataMember(Name="header", EmitDefaultValue=false)]
        public Header header { get; set; }
    }
}
