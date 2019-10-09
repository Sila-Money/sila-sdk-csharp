using System;

namespace SilaAPI.silamoney.client.exceptions
{
    /// <summary>
    /// Exception used when server returns status code 500.
    /// </summary>
    public class ServerSideException : Exception
    {
        /// <summary>
        /// ServerSideException constructor.
        /// </summary>
        public ServerSideException() : base(String.Format("Server Internal Error."))
        {
        }
    }
}
