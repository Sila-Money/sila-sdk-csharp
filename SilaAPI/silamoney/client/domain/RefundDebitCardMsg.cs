using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetWalletStatementDataMsg object used in the get_wallet_statement_data endpoint
    /// </summary>
    [DataContract]
    public partial class RefundDebitCardMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[DataMember(Name = "message", EmitDefaultValue = false)]
        //public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="transactionid"></param>
        public RefundDebitCardMsg(string userHandle, string authHandle, string transactionid)
        {
            this.Header = new Header(userHandle, authHandle);
            this.TransactionId = transactionid;
            //this.Message = "statements";
        }


    }
}
