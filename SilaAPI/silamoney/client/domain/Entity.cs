using Newtonsoft.Json;
using SilaAPI.silamoney.client.util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Entity object used in the entity_msg object
    /// </summary>
    [DataContract]
    public partial class Entity
    {
        /// <summary>
        /// Enum field used in the Entity object to select relationship
        /// </summary>
        [DataMember(Name = "relationship", EmitDefaultValue = false)]
        public Relationship? RelationshipOption { get; set; }
        /// <summary>
        /// Datetime field used in the Entity object to save birthdate
        /// </summary>
        [DataMember(Name = "birthdate", EmitDefaultValue = false)]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// String field used in the Entity object to save entity name
        /// </summary>
        [DataMember(Name = "entity_name", EmitDefaultValue = false)]
        public string EntityName { get; set; }
        /// <summary>
        /// String field used in the Entity object to save last name
        /// </summary>
        [DataMember(Name = "last_name", EmitDefaultValue = false)]
        public string LastName { get; set; }
        /// <summary>
        /// String field used in the Entity object to save first name
        /// </summary>
        [DataMember(Name = "first_name", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// If user is not null, set user values in the Entity object
        /// </summary>
        /// <param name="user"></param>
        public Entity(User user)
        {
            if (user != null)
            {
                this.Birthdate = user.Birthdate;
                this.EntityName = user.EntityName;
                this.FirstName = user.FirstName;
                this.LastName = user.LastName;
                this.RelationshipOption = Relationship.User;
            }
        }
    }
}
