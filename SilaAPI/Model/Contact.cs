using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.Model
{
    [DataContract]
    public partial class Contact
    {
        public Contact(string phone = default(string), string contactAlias = default(string), string email = default(string))
        {
            if (phone == null)
            {
                throw new InvalidDataException("phone is a required property for Contact and cannot be null");
            }
            else
            {
                this.phone = phone;
            }
            if (contactAlias == null)
            {
                throw new InvalidDataException("contactAlias is a required property for Contact and cannot be null");
            }
            else
            {
                this.contactAlias = contactAlias;
            }
            if (email == null)
            {
                throw new InvalidDataException("email is a required property for Contact and cannot be null");
            }
            else
            {
                this.email = email;
            }
        }
        
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string phone { get; set; }

        [DataMember(Name="contact_alias", EmitDefaultValue=false)]
        public string contactAlias { get; set; }

        [DataMember(Name="email", EmitDefaultValue=false)]
        public string email { get; set; }
    }
}
