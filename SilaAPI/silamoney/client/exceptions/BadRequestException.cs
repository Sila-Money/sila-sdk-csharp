using System;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.exceptions
{
    /// <summary>
    /// Exception used when server returns status code 400 or 403.
    /// </summary>
    [Serializable]
    public class BadRequestException : Exception
    {
        /// <summary>
        /// BadRequestException constructor.
        /// </summary>
        /// <param name="message"></param>
        public BadRequestException(string message) : base(String.Format("Bad Request: {0}", message))
        {
        }

        /// <summary>
        /// BadRequestException constructor.
        /// </summary>
        public BadRequestException()
        {
        }

        /// <summary>
        /// BadRequestException constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
