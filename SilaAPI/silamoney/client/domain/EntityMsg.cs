using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Message used in the register endpoint
    /// </summary>
    public partial class EntityMsg : BaseMessage
    {
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public Address address { get; set; }
        [DataMember(Name = "identity", EmitDefaultValue = false)]
        public Identity identity { get; set; }
        [DataMember(Name = "contact", EmitDefaultValue = false)]
        public Contact contact { get; set; }
        [DataMember(Name = "crypto_entry", EmitDefaultValue = false)]
        public CryptoEntry cryptoEntry { get; set; }
        [DataMember(Name = "entity", EmitDefaultValue = false)]
        public Entity entity { get; set; }

        public EntityMsg(User user, string appHandle)
        {
            if (user != null && appHandle != null)
            {
                this.header = new Header(user.userHandle, appHandle);
                this.address = new Address(user);
                this.identity = new Identity(user);
                this.contact = new Contact(user);
                this.cryptoEntry = new CryptoEntry(user);
                this.entity = new Entity(user);
                this.message = MessageEnum.EntityMsg;
            }
        }
    }
}
