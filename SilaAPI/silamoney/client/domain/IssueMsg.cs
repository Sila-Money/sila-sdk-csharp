using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace SilaAPI.silamoney.client.domain
{
    public partial class IssueMsg : TransactionMessage
    {
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string accountName { get; set; }

        public IssueMsg(string userHandle,
            float amount,
            string userPrivateKey,
            string authHandle,
            string accountName)
        {
            this.header = new Header(userHandle, authHandle);
            this.amount = amount;
            this.message = MessageEnum.IssueMsg;
            this.accountName = accountName;
        }
    }
}
