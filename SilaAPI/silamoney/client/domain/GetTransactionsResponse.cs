using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    public class GetTransactionsResponse
    {
        public string reference { get; set; }
        public GetTransactionsResult message { get; set; }
        public string status { get; set; }
    }
}
