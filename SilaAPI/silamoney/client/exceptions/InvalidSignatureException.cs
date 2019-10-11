using System;

namespace SilaAPI.silamoney.client.exceptions
{
    /// <summary>
    /// Exception used when server returns status code 401.
    /// </summary>
    [Serializable]
    public class InvalidSignatureException : Exception
    {
        /// <summary>
        /// InvalidSignatureException constructor.
        /// </summary>
        /// <param name="message"></param>
        public InvalidSignatureException(string message) : base(String.Format("Unauthorized: {0}", message))
        {
        }
        /// <summary>
        /// InvalidSignatureException constructor.
        /// </summary>
        public InvalidSignatureException()
        {
        }
        /// <summary>
        /// InvalidSignatureException constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InvalidSignatureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
