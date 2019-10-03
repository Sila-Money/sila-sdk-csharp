using System;
using System.Linq;
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
    public partial class GetTransactionsMsg
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MessageEnum
        {
            [EnumMember(Value = "get_transactions_msg")]
            Msg = 1
        }

        [DataMember(Name="message", EmitDefaultValue=false)]
        public MessageEnum message { get; set; }

        public GetTransactionsMsg(Header header = default(Header), SearchFilters searchFilters = default(SearchFilters))
        {
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for GetTransactionsMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.searchFilters = searchFilters;
            this.message = MessageEnum.Msg;
        }
        
        [DataMember(Name="header", EmitDefaultValue=false)]
        public Header header { get; set; }

        [DataMember(Name="search_filters", EmitDefaultValue=false)]
        public SearchFilters searchFilters { get; set; }
    }
}
