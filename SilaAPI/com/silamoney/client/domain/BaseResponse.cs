using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.com.silamoney.client.domain
{
    public class BaseResponse
    {
        public string reference { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }
}
