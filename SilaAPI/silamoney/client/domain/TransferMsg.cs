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
        [DataMember(Name = "destination_handle", EmitDefaultValue = false)]
        public string DestinationHandle { get; set; }

        /// <summary>
        /// String field used in the TransferMsgTransferMsg object to save destination
        /// </summary>
        [DataMember(Name = "destination_address", EmitDefaultValue = false)]
        public string DestinationAddress { get; set; }

        /// <summary>
        /// String field used in the TransferMsgTransferMsg object to save destination
        /// </summary>
        [DataMember(Name = "destination_wallet", EmitDefaultValue = false)]
        public string DestinationWallet { get; set; }

        /// <summary>
        /// TransferMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="destinationHandle"></param>       
        /// <param name="authHandle"></param>
        /// <param name="destinationAddress"></param> 
        /// <param name="destinationWallet"></param>
        /// <param name="descriptor"></param>
        /// <param name="businessUuid"></param>
        public TransferMsg(string userHandle,
            int amount,
            string destinationHandle,
            string authHandle,
            string destinationAddress,
            string destinationWallet,
            string descriptor,
            string businessUuid)
        {
            Header = new Header(userHandle, authHandle);
            DestinationHandle = destinationHandle;
            Amount = amount;
            MessageOption = Message.TransferMsg;
            DestinationAddress = destinationAddress;
            DestinationWallet = destinationWallet;
            Descriptor = descriptor;
            BusinessUuid = businessUuid;
        }
    }
}
