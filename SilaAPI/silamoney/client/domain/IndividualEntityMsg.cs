using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class IndividualEntityMsg : RegistrationDataMsg
    {
        [DataMember(Name = "first_name", EmitDefaultValue = false)]
        public string FirstName { get; set; }
        [DataMember(Name = "last_name", EmitDefaultValue = false)]
        public string LastName { get; set; }
        [DataMember(Name = "entity_name", EmitDefaultValue = false)]
        public string EntityName { get; set; }
        [DataMember(Name = "birthdate", EmitDefaultValue = false)]
        public string BirthDate { get; set; }
        public IndividualEntityMsg(string authHandle, string userHandle, IndividualEntityMessage entity) : base(authHandle, userHandle)
        {
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            EntityName = entity.EntityName;
            BirthDate = entity.BirthDate.HasValue ? entity.BirthDate.Value.ToString("yyyy-MM-dd") : null;
        }
    }
}
