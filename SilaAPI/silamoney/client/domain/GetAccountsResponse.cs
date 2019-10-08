﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    public class GetAccountsResponse
    {
        public string reference { get; set; }
        public List<Account> message { get; set; }
        public string status { get; set; }
    }
}
