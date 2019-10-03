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
    public partial class EntityMsg
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MessageEnum
        {
            [EnumMember(Value = "entity_msg")]
            Msg = 1
        }

        [DataMember(Name="message", EmitDefaultValue=false)]
        public MessageEnum message { get; set; }

        public EntityMsg(Address address = default(Address), Identity identity = default(Identity), Contact contact = default(Contact), Header header = default(Header), CryptoEntry cryptoEntry = default(CryptoEntry), Entity entity = default(Entity))
        {
            if (address == null)
            {
                throw new InvalidDataException("address is a required property for EntityMsg and cannot be null");
            }
            else
            {
                this.address = address;
            }
            if (identity == null)
            {
                throw new InvalidDataException("identity is a required property for EntityMsg and cannot be null");
            }
            else
            {
                this.identity = identity;
            }
            if (contact == null)
            {
                throw new InvalidDataException("contact is a required property for EntityMsg and cannot be null");
            }
            else
            {
                this.contact = contact;
            }
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for EntityMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            if (cryptoEntry == null)
            {
                throw new InvalidDataException("cryptoEntry is a required property for EntityMsg and cannot be null");
            }
            else
            {
                this.cryptoEntry = cryptoEntry;
            }
            if (entity == null)
            {
                throw new InvalidDataException("entity is a required property for EntityMsg and cannot be null");
            }
            else
            {
                this.entity = entity;
            }
            this.message = MessageEnum.Msg;
        }


        [DataMember(Name="address", EmitDefaultValue=false)]
        public Address address { get; set; }

        [DataMember(Name="identity", EmitDefaultValue=false)]
        public Identity identity { get; set; }

        [DataMember(Name="contact", EmitDefaultValue=false)]
        public Contact contact { get; set; }

        [DataMember(Name="header", EmitDefaultValue=false)]
        public Header header { get; set; }

        [DataMember(Name="crypto_entry", EmitDefaultValue=false)]
        public CryptoEntry cryptoEntry { get; set; }

        [DataMember(Name="entity", EmitDefaultValue=false)]
        public Entity entity { get; set; }
    }
}
