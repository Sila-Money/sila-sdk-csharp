using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// TransactionMessage object use in different endpoints
    /// </summary>
    [DataContract]
    public class TransactionMessage : BaseMessage
    {
        /// <summary>
        /// Int field use in the TransactionMessage object to save amount
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public int? Amount { get; set; }

        /// <summary>
        /// String field use in the TransactionMessage object to save descriptor
        /// </summary>
        [DataMember(Name = "descriptor", EmitDefaultValue = false)]
        public string Descriptor { get; set; }

        /// <summary>
        /// String field use in the TransactionMessage object to save business uuid
        /// </summary>
        [DataMember(Name = "business_uuid", EmitDefaultValue = false)]
        public string BusinessUuid { get; set; }
    }
}
