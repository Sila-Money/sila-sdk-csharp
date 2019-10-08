using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.exceptions
{
    public class ServerSideException : Exception
    {
        public ServerSideException() : base(String.Format("Server Internal Error."))
        {
        }
    }
}
