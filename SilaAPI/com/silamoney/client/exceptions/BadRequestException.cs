using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.com.silamoney.client.exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(String.Format("Bad Request: {0}", message))
        {
        }
    }
}
