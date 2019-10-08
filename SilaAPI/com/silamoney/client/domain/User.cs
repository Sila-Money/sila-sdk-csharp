using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.com.silamoney.client.domain
{
    public class User
    {
        
        public string userHandle { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string entityName { get; set; }
        public string identityValue { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string streetAddress1 { get; set; }
        public string streetAddress2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string portalCode { get; set; }
        public string cryptopAddress { get; set; }
        public DateTime birthdate { get; set; }

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
