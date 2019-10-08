using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.exceptions
{
    public class InvalidSignatureException : Exception
    {
        public InvalidSignatureException(string message) : base(String.Format("Unauthorized: {0}", message))
        {
        }
    }
}
