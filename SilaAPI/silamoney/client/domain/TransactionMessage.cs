using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public class TransactionMessage : BaseMessage
    {
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public float? amount { get; set; }
    }
}
