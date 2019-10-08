using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    public class SilaBalanceRequest
    {
        public string address { get; set; }

        public SilaBalanceRequest(string address)
        {
            this.address = address;
        }
    }
}
