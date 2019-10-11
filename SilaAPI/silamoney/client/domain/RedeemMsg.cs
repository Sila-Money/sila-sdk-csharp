using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// RedeemMsg object used in the redeem_sila endpoint
    /// </summary>
    public partial class RedeemMsg : TransactionMessage
    {
        /// <summary>
        /// String field used in the RedeemMsg object to save account name
        /// </summary>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string AccountName { get; set; }

        /// <summary>
        /// RedeemMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="authHandle"></param>
        /// <param name="accountName"></param>
        public RedeemMsg(string userHandle,
            float amount,
            string authHandle,
            string accountName)
        {
            this.Header = new Header(userHandle, authHandle);
            this.Amount = amount;
            this.AccountName = accountName;
            this.MessageOption = Message.RedeemMsg;
        }
    }
}
