using System.Runtime.Serialization;

namespace SilaAPI.com.silamoney.client.domain
{
    public class TransactionMessage : BaseMessage
    {
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public float? amount { get; set; }
    }
}
