namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// User object in Address, Contact, CryptoEntry, Entity, EntityMsg, Header, Identity, User objects
    /// </summary>
    public class BusinessUser : BaseUser
    {
        /// <summary>
        /// Business type set to business user.
        /// </summary>
        public string BusinessType { get; set; }
        /// <summary>
        /// String field used in the BusinessUser object to save business website.
        /// </summary>
        public string BusinessWebsite { get; set; }
        /// <summary>
        /// String field used in the BusinessUser object to save doing business as.
        /// </summary>
        public string DoingBusinessAs { get; set; }
        /// <summary>
        /// Int field used in the BusinessUser object to save the naics code.
        /// </summary>
        public int? NaicsCode { get; set; }
        /// <summary>
        /// Must be a valid UUID4 string. 
        /// Get from allowed business types in /get_business_types endpoint.
        /// Required if business_type is not set
        /// </summary>
        public string BusinessTypeUuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RegistrationState { get; set; }
        

        /// <summary>
        /// 
        /// </summary>
        public BusinessUser() { }

        /// <summary>
        /// User constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="entityName"></param>
        /// <param name="identityValue"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="streetAddress1"></param>
        /// <param name="streetAddress2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="postalCode"></param>
        /// <param name="cryptopAddress"></param>
        /// <param name="businessType"></param>
        /// <param name="businessWebsite"></param>
        /// <param name="doingBusinessAs"></param>
        /// <param name="naicsCode"></param>
        /// <param name="country"></param>
        /// <param name="contactAlias"></param>
        /// <param name="cryptoAlias"></param>
        /// <param name="addressAlias"></param>
        /// <param name="type"></param>
        /// <param name="registrationState"></param>
        public BusinessUser(string userHandle, string entityName = null, string identityValue = null, string phone = null,
        string email = null, string streetAddress1 = null, string streetAddress2 = null, string city = null, string state = null, string postalCode = null,
        string cryptopAddress = null, BusinessType businessType = null, string businessWebsite = null, string doingBusinessAs = null, int? naicsCode = null,
        string country = null, string contactAlias = null, string cryptoAlias = null, string addressAlias = null, string type = null,
        string registrationState =null)
        {
            UserHandle = userHandle;
            EntityName = entityName;
            IdentityValue = identityValue;
            Phone = phone;
            Email = email;
            StreetAddress1 = streetAddress1;
            StreetAddress2 = streetAddress2;
            City = city;
            State = state;
            PostalCode = postalCode;
            CryptoAddress = cryptopAddress;
            BusinessType = businessType.Name;
            BusinessWebsite = businessWebsite;
            DoingBusinessAs = doingBusinessAs;
            NaicsCode = naicsCode;
            Country = country;
            ContactAlias = contactAlias;
            CryptoAlias = cryptoAlias;
            AddressAlias = addressAlias;
            Type = type;
            RegistrationState = registrationState;
        }
    }
}