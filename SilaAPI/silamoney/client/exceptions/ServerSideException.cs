using System;

namespace SilaAPI.silamoney.client.exceptions
{
    /// <summary>
    /// Exception used when server returns status code 500.
    /// </summary>
    [Serializable]
    public class ServerSideException : Exception
    {
        /// <summary>
        /// ServerSideException constructor.
        /// </summary>
        public ServerSideException() : base("Server Internal Error.")
        {
        }
        /// <summary>
        /// ServerSideException constructor.
        /// </summary>
        /// <param name="message"></param>
        public ServerSideException(string message) : base(message)
        {
        }
        /// <summary>
        /// ServerSideException constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ServerSideException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
