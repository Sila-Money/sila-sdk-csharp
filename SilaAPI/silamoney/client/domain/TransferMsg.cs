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
        public string Destination { get; set; }

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
            this.Header = new Header(userHandle, authHandle);
            this.Destination = destinationHandle;
            this.Amount = amount;
            this.MessageOption = Message.TransferMsg;
        }
    }
}
