using System;
using System.Collections.Generic;
using System.Text;

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
        public string userHandle { get; set; }
        /// <summary>
        /// String field used in the User object to save firstName
        /// </summary>
        public string firstName { get; set; }
        /// <summary>
        /// String field used in the User object to save lastName
        /// </summary>
        public string lastName { get; set; }
        /// <summary>
        /// String field used in the User object to save entityName
        /// </summary>
        public string entityName { get; set; }
        /// <summary>
        /// String field used in the User object to save identityValue
        /// </summary>
        public string identityValue { get; set; }
        /// <summary>
        /// String field used in the User object to save phone
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// String field used in the User object to save email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// String field used in the User object to save streetAddress1
        /// </summary>
        public string streetAddress1 { get; set; }
        /// <summary>
        /// String field used in the User object to save streetAddress2
        /// </summary>
        /// <value></value>
        public string streetAddress2 { get; set; }
        /// <summary>
        /// String field used in the User object to save city
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// String field used in the User object to save state
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// String field used in the User object to save portalCode
        /// </summary>
        public string portalCode { get; set; }
        /// <summary>
        /// String field used in the User object to save cryptopAddress
        /// </summary>
        public string cryptopAddress { get; set; }
        /// <summary>
        /// DateTime field used in the User object to save birthdate
        /// </summary>
        public DateTime birthdate { get; set; }

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
        /// <param name="portalCode"></param>
        /// <param name="cryptopAddress"></param>
        /// <param name="birthdate"></param>
        public User(string userHandle, string firstName, string lastName, string entityName, string identityValue, string phone, 
            string email, string streetAddress1, string streetAddress2, string city, string state, string portalCode, 
            string cryptopAddress, DateTime birthdate)
        {
            this.userHandle = userHandle;
            this.firstName = firstName;
            this.lastName = lastName;
            this.entityName = entityName;
            this.identityValue = identityValue;
            this.phone = phone;
            this.email = email;
            this.streetAddress1 = streetAddress1;
            this.streetAddress2 = streetAddress2;
            this.city = city;
            this.state = state;
            this.portalCode = portalCode;
            this.cryptopAddress = cryptopAddress;
            this.birthdate = birthdate;
        }
    }
}
