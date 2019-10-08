using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace SilaAPI.com.silamoney.client.domain
{
    public partial class IssueMsg : TransactionMessage
    {
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string accountName { get; set; }

        public IssueMsg(float? amount = default(float?),
            string accountName = default(string),
            Header header = default(Header))
        {
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for IssueMsg and cannot be null");
            }
            else
            {
                this.amount = amount;
            }
            if (accountName == null)
            {
                throw new InvalidDataException("accountName is a required property for IssueMsg and cannot be null");
            }
            else
            {
                this.accountName = accountName;
            }
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for IssueMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.message = MessageEnum.IssueMsg;
        }
    }
}
