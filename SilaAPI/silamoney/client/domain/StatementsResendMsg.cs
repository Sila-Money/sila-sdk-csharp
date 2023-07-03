using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetWalletStatementDataMsg object used in the get_wallet_statement_data endpoint
    /// </summary>
    [DataContract]
    public partial class StatementsResendMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="searchFilters"></param>
        public StatementsResendMsg(string userHandle, string authHandle, StatementsSearchFilters searchFilters = null)
        {
            this.Header = new Header(userHandle, authHandle);
            this.Email = searchFilters?.Email;
            this.Message = "header_msg";
        }


    }
}
