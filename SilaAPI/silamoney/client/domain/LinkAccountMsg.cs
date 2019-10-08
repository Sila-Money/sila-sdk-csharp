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
    public partial class LinkAccountMsg : BaseMessage
    {
        [DataMember(Name = "public_token", EmitDefaultValue = false)]
        public string publicToken { get; set; }
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string accountName { get; set; }
        [DataMember(Name = "selected_account_id", EmitDefaultValue = false)]
        public string selectedAccountId { get; set; }

        public LinkAccountMsg(string userHandle,
            string publicToken,
            string privateKey,
            string appHandler,
            string accountName)
        {
            this.header = new Header(userHandle,appHandler);
            this.publicToken = publicToken;
            this.message = MessageEnum.LinkAccountMsg;
            this.accountName = accountName;
        }
    }
}
