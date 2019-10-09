using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// TransactionMessage object use in different endpoints
    /// </summary>
    public class TransactionMessage : BaseMessage
    {
        /// <summary>
        /// Float field use in the TransactionMessage object to save amount
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public float? amount { get; set; }
    }
}
