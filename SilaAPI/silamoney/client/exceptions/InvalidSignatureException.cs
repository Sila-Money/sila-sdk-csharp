using System;

namespace SilaAPI.silamoney.client.exceptions
{
    /// <summary>
    /// Exception used when server returns status code 401.
    /// </summary>
    public class InvalidSignatureException : Exception
    {
        /// <summary>
        /// InvalidSignatureException constructor.
        /// </summary>
        /// <param name="message"></param>
        public InvalidSignatureException(string message) : base(String.Format("Unauthorized: {0}", message))
        {
        }
    }
}
