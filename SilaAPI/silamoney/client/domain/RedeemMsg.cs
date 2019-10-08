using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SilaAPI.silamoney.client.domain
{
    public partial class RedeemMsg : TransactionMessage
    {
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string accountName { get; set; }

        public RedeemMsg(string userHandle,
            float amount,
            string authHandle,
            string accountName)
        {
            this.header = new Header(userHandle, authHandle);
            this.amount = amount;
            this.accountName = accountName;
            this.message = MessageEnum.RedeemMsg;
        }
    }
}
