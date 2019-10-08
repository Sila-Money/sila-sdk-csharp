using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.com.silamoney.client.domain
{
    [DataContract]
    public partial class Contact
    {
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public string phone { get; set; }
        [DataMember(Name = "contact_alias", EmitDefaultValue = false)]
        public string contactAlias { get; set; }
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string email { get; set; }

        public Contact(User user)
        {
            if (user != null)
            {
                this.contactAlias = "";
                this.email = user.email;
                this.phone = user.phone;
            }
        }
    }
}
