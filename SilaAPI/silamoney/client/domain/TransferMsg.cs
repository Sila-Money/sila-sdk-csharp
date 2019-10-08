using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class TransferMsg : TransactionMessage
    {
        [DataMember(Name = "destination", EmitDefaultValue = false)]
        public string destination { get; set; }

        public TransferMsg(string userHandle,
            float amount,
            string destinationHandle,
            string authHandle)
        {
            this.header = new Header(userHandle, authHandle);
            this.destination = destinationHandle;
            this.amount = amount;
            this.message = MessageEnum.TransferMsg;
        }
    }
}
