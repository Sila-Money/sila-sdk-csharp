using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// TransferMsg object used in the transfer_sila endpoint
    /// </summary>
    public partial class TransferMsg : TransactionMessage
    {
        /// <summary>
        /// String field used in the TransferMsgTransferMsg object to save destination
        /// </summary>
        [DataMember(Name = "destination", EmitDefaultValue = false)]
        public string destination { get; set; }

        /// <summary>
        /// TransferMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="destinationHandle"></param>
        /// <param name="authHandle"></param>
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
