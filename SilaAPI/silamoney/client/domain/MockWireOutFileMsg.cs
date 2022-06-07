using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// MockWireOutFileMsg object used in the MockWireOutFile endpoint
    /// </summary>
    [DataContract]
    public partial class MockWireOutFileMsg
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
        [DataMember(Name = "wire_status", EmitDefaultValue = false)]
        public string WireStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="transactionId"></param>
        /// <param name="wireStatus"></param>
        public MockWireOutFileMsg(string userHandle, string authHandle, string transactionId, string wireStatus)
        {
            this.Header = new Header(userHandle, authHandle);
            this.TransactionId = transactionId;
            this.WireStatus = wireStatus;
        }
    }
}
