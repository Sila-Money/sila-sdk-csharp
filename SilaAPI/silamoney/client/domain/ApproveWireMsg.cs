using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// ApproveWireMsg object used in the ApproveWire endpoint
    /// </summary>
    [DataContract]
    public partial class ApproveWireMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "transaction_id", EmitDefaultValue = false)]
        public string TransactionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "approve")]
        public bool Approve { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "notes", EmitDefaultValue = false)]
        public string Notes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "mock_wire_account_name", EmitDefaultValue = false)]
        public string MockWireAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="transactionId"></param>
        /// <param name="approve"></param>
        /// <param name="notes"></param>
        /// <param name="mockWireAccountName"></param>
        public ApproveWireMsg(string userHandle, string authHandle, string transactionId, bool approve, string notes, string mockWireAccountName)
        {
            this.Header = new Header(userHandle, authHandle);
            this.TransactionId = transactionId;
            this.Approve = approve;
            this.Notes = notes;
            this.MockWireAccountName = mockWireAccountName;
        }
    }
}
