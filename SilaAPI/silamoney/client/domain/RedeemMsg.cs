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

        public RedeemMsg(string accountName = default(string),
            float? amount = default(float?),
            Header header = default(Header))
        {
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for RedeemMsg and cannot be null");
            }
            else
            {
                this.amount = amount;
            }
            if (accountName == null)
            {
                throw new InvalidDataException("accountName is a required property for RedeemMsg and cannot be null");
            }
            else
            {
                this.accountName = accountName;
            }
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for RedeemMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.message = MessageEnum.RedeemMsg;
        }
    }
}
