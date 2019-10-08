using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using SilaAPI.com.silamoney.client.util;

namespace SilaAPI.com.silamoney.client.domain
{
    [DataContract]
    public partial class Entity
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RelationshipEnum
        {
            [EnumMember(Value = "organization")]
            Organization = 1,
            [EnumMember(Value = "developer")]
            Developer = 2,
            [EnumMember(Value = "user")]
            User = 3,
            [EnumMember(Value = "vendor")]
            Vendor = 4
        }

        [DataMember(Name="relationship", EmitDefaultValue=false)]
        public RelationshipEnum? relationship { get; set; }
        [DataMember(Name = "birthdate", EmitDefaultValue = false)]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? birthdate { get; set; }
        [DataMember(Name = "entity_name", EmitDefaultValue = false)]
        public string entityName { get; set; }
        [DataMember(Name = "last_name", EmitDefaultValue = false)]
        public string lastName { get; set; }
        [DataMember(Name = "first_name", EmitDefaultValue = false)]
        public string firstName { get; set; }
        
        public Entity(User user)
        {
            if (user != null)
            {
                this.birthdate = user.birthdate;
                this.entityName = user.entityName;
                this.firstName = user.firstName;
                this.lastName = user.lastName;
                this.relationship = RelationshipEnum.User;
            }
        }
    }
}
