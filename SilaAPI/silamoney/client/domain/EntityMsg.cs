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
        /// Device object field used in the EntityMsg object to save a device fingerprint
        /// </summary>
        [DataMember(Name = "device", EmitDefaultValue = false)]
        public Device Device { get; set; }

        /// <summary>
        /// If user and appHandle are not null, set user values in the differents object
        /// </summary>
        /// <param name="user"></param>
        /// <param name="appHandle"></param>
        public EntityMsg(User user, string appHandle)
        {
            if (user != null && appHandle != null)
            {
                Header = new Header(user.UserHandle, appHandle);
                if (user.AddressAlias != null || user.StreetAddress1 != null || user.StreetAddress2 != null || user.City != null || user.State != null || user.Country != null || user.PostalCode != null)
                    Address = new Address(user);
                if (user.IdentityValue != null)
                    Identity = new Identity(user);
                if (user.Phone != null || user.Email != null || user.ContactAlias != null)
                    Contact = new Contact(user);
                if (user.CryptoAddress != null || user.CryptoAlias != null)
                    CryptoEntry = new CryptoEntry(user);
                if (user.FirstName != null || user.LastName != null || user.EntityName != null || user.Birthdate.HasValue)
                    Entity = new Entity(user);
                if (user.DeviceFingerprint != null)
                    Device = new Device
                    {
                        DeviceFingerprint = user.DeviceFingerprint
                    };
                MessageOption = Message.EntityMsg;
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
                if (user.AddressAlias != null || user.StreetAddress1 != null || user.StreetAddress2 != null || user.City != null || user.State != null || user.Country != null || user.PostalCode != null)
                    this.Address = new Address(user);
                if (user.IdentityValue != null)
                    this.Identity = new Identity(user);
                if (user.Phone != null || user.Email != null || user.ContactAlias != null)
                    this.Contact = new Contact(user);
                if (user.CryptoAddress != null || user.CryptoAlias != null)
                    this.CryptoEntry = new CryptoEntry(user);
                if (user.EntityName != null || user.Type != null || user.BusinessType != null || user.BusinessWebsite != null || user.DoingBusinessAs != null || user.NaicsCode.HasValue || user.BusinessTypeUuid != null)
                    this.Entity = new Entity(user);
                this.MessageOption = Message.EntityMsg;
            }
        }
    }
}
