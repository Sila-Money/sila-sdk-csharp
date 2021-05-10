using System.Runtime.Serialization;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Contact object used in the entity_msg object
    /// </summary>
    [DataContract]
    public class Contact
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
        /// Optional. If true, if and if app is configured with an SMS flow, triggers sending a confirmation SMS to the phone number in contact.phone. If no contact.phone field was provided, this is ignored.
        /// </summary>
        [DataMember(Name = "sms_opt_in", EmitDefaultValue = false)]
        public bool? SmsOptIn { get; set; }
    }
}
