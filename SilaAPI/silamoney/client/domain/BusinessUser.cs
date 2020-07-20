namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// User object in Address, Contact, CryptoEntry, Entity, EntityMsg, Header, Identity, User objects
    /// </summary>
    public class BusinessUser
    {

        /// <summary>
        /// String field used in the User object to save userHandle
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// String field used in the User object to save entityName
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// String field used in the User object to save identityValue
        /// </summary>
        public string IdentityValue { get; set; }
        /// <summary>
        /// String field used in the User object to save phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// String field used in the User object to save email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// String field used in the User object to save streetAddress1
        /// </summary>
        public string StreetAddress1 { get; set; }
        /// <summary>
        /// String field used in the User object to save streetAddress2
        /// </summary>
        /// <value></value>
        public string StreetAddress2 { get; set; }
        /// <summary>
        /// String field used in the User object to save city
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// String field used in the User object to save state
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// String field used in the User object to save postalCode
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// String field used in the User object to save cryptopAddress
        /// </summary>
        public string CryptopAddress { get; set; }
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
        public int NaicsCode { get; set; }

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
        public BusinessUser(string userHandle, string entityName, string identityValue, string phone,
        string email, string streetAddress1, string streetAddress2, string city, string state, string postalCode,
        string cryptopAddress, BusinessType businessType, string businessWebsite, string doingBusinessAs, int naicsCode)
        {
            this.UserHandle = userHandle;
            this.EntityName = entityName;
            this.IdentityValue = identityValue;
            this.Phone = phone;
            this.Email = email;
            this.StreetAddress1 = streetAddress1;
            this.StreetAddress2 = streetAddress2;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.CryptopAddress = cryptopAddress;
            this.BusinessType = businessType.Name;
            this.BusinessWebsite = businessWebsite;
            this.DoingBusinessAs = doingBusinessAs;
            this.NaicsCode = naicsCode;
        }
    }
}