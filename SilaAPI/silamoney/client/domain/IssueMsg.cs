using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// IssueMsg object used in the issue_sila endpoint
    /// </summary>
    public partial class IssueMsg : TransactionMessage
    {
        /// <summary>
        /// String field used in the IssueMsg object to save account name
        /// </summary>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string accountName { get; set; }

        /// <summary>
        /// IssueMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="authHandle"></param>
        /// <param name="accountName"></param>
        public IssueMsg(string userHandle,
            float amount,
            string authHandle,
            string accountName)
        {
            this.Header = new Header(userHandle, authHandle);
            this.amount = amount;
            this.MessageOption = Message.IssueMsg;
            this.accountName = accountName;
        }
    }
}
