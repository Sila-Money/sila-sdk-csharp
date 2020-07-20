using System;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Message used in the register endpoint
    /// </summary>
    public partial class EntityMsg : BaseMessage
    {
        /// <summary>
        /// Address object field used in the EntityMsg object to save address
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public Address Address { get; set; }
        /// <summary>
        /// Identity object field used in the EntityMsg object to save identity
        /// </summary>
        [DataMember(Name = "identity", EmitDefaultValue = false)]
        public Identity Identity { get; set; }
        /// <summary>
        /// Contact object field used in the EntityMsg object to save contact
        /// </summary>
        [DataMember(Name = "contact", EmitDefaultValue = false)]
        public Contact Contact { get; set; }
        /// <summary>
        /// CryptoEntry object field used in the EntityMsg object to save crypto entry
        /// </summary>
        [DataMember(Name = "crypto_entry", EmitDefaultValue = false)]
        public CryptoEntry CryptoEntry { get; set; }
        /// <summary>
        /// Entity object field used in the EntityMsg object to save entity
        /// </summary>
        [DataMember(Name = "entity", EmitDefaultValue = false)]
        public Entity Entity { get; set; }

        /// <summary>
        /// If user and appHandle are not null, set user values in the differents object
        /// </summary>
        /// <param name="user"></param>
        /// <param name="appHandle"></param>
        public EntityMsg(User user, string appHandle)
        {
            if (user != null && appHandle != null)
            {
                this.Header = new Header(user.UserHandle, appHandle);
                this.Address = new Address(user);
                this.Identity = new Identity(user);
                this.Contact = new Contact(user);
                this.CryptoEntry = new CryptoEntry(user);
                this.Entity = new Entity(user);
                this.MessageOption = Message.EntityMsg;
            }
        }

        /// <summary>
        /// If user and appHandle are not null, set user values in the differents object
        /// </summary>
        /// <param name="user"></param>
        /// <param name="appHandle"></param>
        public EntityMsg(BusinessUser user, string appHandle)
        {
            if (user != null && appHandle != null)
            {
                this.Header = new Header(user.UserHandle, appHandle);
                this.Address = new Address(user);
                this.Identity = new Identity(user);
                this.Contact = new Contact(user);
                this.CryptoEntry = new CryptoEntry(user);
                this.Entity = new Entity(user);
                this.MessageOption = Message.EntityMsg;
            }
        }
    }
}
