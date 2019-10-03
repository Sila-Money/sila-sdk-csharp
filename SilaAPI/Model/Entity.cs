using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using SilaAPI.Client;

namespace SilaAPI.Model
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

        public Entity(DateTime? birthdate = default(DateTime?), string entityName = default(string), string lastName = default(string), RelationshipEnum? relationship = default(RelationshipEnum?), string firstName = default(string))
        {
            if (birthdate == null)
            {
                throw new InvalidDataException("birthdate is a required property for Address and cannot be null");
            }
            else {
                this.birthdate = birthdate;
            }

            if (entityName == null)
            {
                throw new InvalidDataException("entity_name is a required property for Address and cannot be null");
            }
            else
            {
                this.entityName = entityName;
            }

            if (lastName == null)
            {
                throw new InvalidDataException("last_name is a required property for Address and cannot be null");
            }
            else
            {
                this.lastName = lastName;
            }

            if (relationship == null)
            {
                throw new InvalidDataException("relationship is a required property for Address and cannot be null");
            }
            else
            {
                this.relationship = relationship;
            }

            if (firstName == null)
            {
                throw new InvalidDataException("first_name is a required property for Address and cannot be null");
            }
            else
            {
                this.firstName = firstName;
            }
        }
        
        [DataMember(Name="birthdate", EmitDefaultValue=false)]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? birthdate { get; set; }

        [DataMember(Name="entity_name", EmitDefaultValue=false)]
        public string entityName { get; set; }

        [DataMember(Name="last_name", EmitDefaultValue=false)]
        public string lastName { get; set; }

        [DataMember(Name="first_name", EmitDefaultValue=false)]
        public string firstName { get; set; }
    }
}
