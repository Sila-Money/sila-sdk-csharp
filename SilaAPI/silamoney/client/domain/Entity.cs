using Newtonsoft.Json;
using SilaAPI.silamoney.client.util;
using System;
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
        /// String field used in the Entity object to save type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }
        /// <summary>
        /// String field used in the Entity object to save business type
        /// </summary>
        [DataMember(Name = "business_type", EmitDefaultValue = false)]
        public string BusinessType { get; set; }
        /// <summary>
        /// String field used in the Entity object to save business website
        /// </summary>
        [DataMember(Name = "business_website", EmitDefaultValue = false)]
        public string BusinessWebsite { get; set; }
        /// <summary>
        /// String field used in the Entity object to save doing business as
        /// </summary>
        [DataMember(Name = "doing_business_as", EmitDefaultValue = false)]
        public string DoingBusinessAs { get; set; }
        /// <summary>
        /// String field used in the Entity object to save naics code
        /// </summary>
        [DataMember(Name = "naics_code", EmitDefaultValue = false)]
        public int? NaicsCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "business_type_uuid", EmitDefaultValue = false)]
        public string BusinessTypeUuid { get; set; }

        /// <summary>
        /// If user is not null, set user values in the Entity object
        /// </summary>
        /// <param name="user"></param>
        public Entity(User user)
        {
            if (user != null)
            {
                Birthdate = user.Birthdate;
                EntityName = user.EntityName;
                FirstName = user.FirstName;
                LastName = user.LastName;
                RelationshipOption = Relationship.User;
                Type = user.Type ?? "individual";
            }
        }

        /// <summary>
        /// If user is not null, set user values in the Entity object
        /// </summary>
        /// <param name="user"></param>
        public Entity(BusinessUser user)
        {
            if (user != null)
            {
                EntityName = user.EntityName;
                BusinessType = user.BusinessType;
                BusinessTypeUuid = user.BusinessTypeUuid;
                BusinessWebsite = user.BusinessWebsite;
                DoingBusinessAs = user.DoingBusinessAs;
                NaicsCode = user.NaicsCode;
                Type = user.Type ?? "business";
            }
        }

        /// <summary>
        /// Entity constructor.
        /// </summary>
        public Entity() { }
    }
}
