using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.com.silamoney.client.domain
{
    public partial class TransferMsg : TransactionMessage
    {
        [DataMember(Name = "destination", EmitDefaultValue = false)]
        public string destination { get; set; }

        public TransferMsg(float? amount = default(float?),
            string destination = default(string),
            Header header = default(Header))
        {
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for TransferMsg and cannot be null");
            }
            else
            {
                this.amount = amount;
            }
            if (destination == null)
            {
                throw new InvalidDataException("destination is a required property for TransferMsg and cannot be null");
            }
            else
            {
                this.destination = destination;
            }
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for TransferMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.message = MessageEnum.TransferMsg;
        }
    }
}
