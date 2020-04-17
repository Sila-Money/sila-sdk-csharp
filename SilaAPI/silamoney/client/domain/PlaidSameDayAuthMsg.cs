using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// PlaidSameDayAuthMsg object used in the plaid same day auth endpoint
    /// </summary>
    [DataContract]
    public partial class PlaidSameDayAuthMsg : BaseMessageNoMsg
    {
        /// <summary>
        /// String field used in the PlaidSameDayAuthMsg object to save account name
        /// </summary>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string AccountName { get; set; }

        /// <summary>
        /// PlaidSameDayAuthMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="accountName"></param>
        public PlaidSameDayAuthMsg(string userHandle,
            string authHandle,
            string accountName)
        {
            Header = new Header(userHandle, authHandle);
            AccountName = accountName;
        }
    }
}
