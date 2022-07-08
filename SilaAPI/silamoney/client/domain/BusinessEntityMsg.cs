using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class BusinessEntityMsg : RegistrationDataMsg
    {
        [DataMember(Name = "entity_name", EmitDefaultValue = false)]
        public string EntityName { get; }
        [DataMember(Name = "business_type", EmitDefaultValue = false)]
        public string BusinessType { get; }
        [DataMember(Name = "naics_code", EmitDefaultValue = false)]
        public int? NaicsCode { get; }
        [DataMember(Name = "doing_business_as", EmitDefaultValue = false)]
        public string DoingBusinessAs { get; }
        [DataMember(Name = "business_website", EmitDefaultValue = false)]
        public string BusinessWebsite { get; }

        [DataMember(Name = "registration_state", EmitDefaultValue = false)]
        public string RegistrationState { get; }

        public BusinessEntityMsg(string authHandle, string userHandle, BusinessEntityMessage entity) : base(authHandle, userHandle)
        {
            EntityName = entity.EntityName;
            BusinessType = entity.BusinessType;
            NaicsCode = entity.NaicsCode;
            DoingBusinessAs = entity.DoingBusinessAs;
            BusinessWebsite = entity.BusinessWebsite;
            RegistrationState = entity.RegistrationState;
        }
    }
}
