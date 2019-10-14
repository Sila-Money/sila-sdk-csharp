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
        public string CryptopAddress { get; set; }
        /// <summary>
        /// DateTime field used in the User object to save birthdate
        /// </summary>
        public DateTime Birthdate { get; set; }

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
        public User(string userHandle, string firstName, string lastName, string entityName, string identityValue, string phone,
            string email, string streetAddress1, string streetAddress2, string city, string state, string postalCode,
            string cryptopAddress, DateTime birthdate)
        {
            this.UserHandle = userHandle;
            this.FirstName = firstName;
            this.LastName = lastName;
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
            this.Birthdate = birthdate;
        }
    }
}
