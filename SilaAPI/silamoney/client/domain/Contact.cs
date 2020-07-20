using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Contact object used in the entity_msg object
    /// </summary>
    [DataContract]
    public partial class Contact
    {
        /// <summary>
        /// String field used in the Contact object to save phone
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public string Phone { get; set; }
        /// <summary>
        /// String field used in the Contact object to save contact alias
        /// </summary>
        [DataMember(Name = "contact_alias", EmitDefaultValue = false)]
        public string ContactAlias { get; set; }
        /// <summary>
        /// String field used in the Contact object to save email
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }
        /// <summary>
        /// If user is not null, set user values in the Contact object
        /// </summary>
        /// <param name="user"></param>
        public Contact(User user)
        {
            if (user != null)
            {
                this.ContactAlias = "";
                this.Email = user.Email;
                this.Phone = user.Phone;
            }
        }

        /// <summary>
        /// If user is not null, set user values in the Contact object
        /// </summary>
        /// <param name="user"></param>
        public Contact(BusinessUser user)
        {
            if (user != null)
            {
                this.ContactAlias = "";
                this.Email = user.Email;
                this.Phone = user.Phone;
            }
        }
    }
}
