using System;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// User object in Address, Contact, CryptoEntry, Entity, EntityMsg, Header, Identity, User objects
    /// </summary>
    public class User
    {
        /// <summary>
        /// String field used in the User object to save userHandle
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// String field used in the User object to save firstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// String field used in the User object to save lastName
        /// </summary>
        public string LastName { get; set; }
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
        public string CryptoAddress { get; set; }
        /// <summary>
        /// DateTime field used in the User object to save birthdate
        /// </summary>
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// String field used to register the country of the user
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// String field used to register an alias for the user contact information
        /// </summary>
        public string ContactAlias { get; set; }
        /// <summary>
        /// String field used to register an alias for the user crypto address
        /// </summary>
        public string CryptoAlias { get; set; }
        /// <summary>
        /// String field used to register an alias for the user address
        /// </summary>
        public string AddressAlias { get; set; }

        /// <summary>
        /// User empty constructor
        /// </summary>
        public User() { }

        /// <summary>
        /// User constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
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
        /// <param name="birthdate"></param>
        /// <param name="country"></param>
        /// <param name="contactAlias"></param>
        /// <param name="cryptoAlias"></param>
        /// <param name="addressAlias"></param>
        public User(string userHandle, string firstName = null, string lastName = null, string entityName = null, string identityValue = null, string phone = null,
            string email = null, string streetAddress1 = null, string streetAddress2 = null, string city = null, string state = null, string postalCode = null,
            string cryptopAddress = null, DateTime? birthdate = null, string country = null, string contactAlias = null, string cryptoAlias = null, string addressAlias = null)
        {
            UserHandle = userHandle;
            FirstName = firstName;
            LastName = lastName;
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
            Birthdate = birthdate;
            Country = country;
            ContactAlias = contactAlias;
            CryptoAlias = cryptoAlias;
            AddressAlias = addressAlias;
        }
    }
}
