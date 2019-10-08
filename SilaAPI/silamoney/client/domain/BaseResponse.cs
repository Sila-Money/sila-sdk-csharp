using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to store response message.
    /// </summary>
    public class BaseResponse
    {
        public string reference { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }
}
