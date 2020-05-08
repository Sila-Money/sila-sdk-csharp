using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    class GetAccountBalanceMsg : BaseMessageNoMsg
    {
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string AccountName { get; }
        public GetAccountBalanceMsg(string userHandle, string appHandle, string accountName)
        {
            Header = new Header(userHandle, appHandle);
            AccountName = accountName;
        }
    }
}
