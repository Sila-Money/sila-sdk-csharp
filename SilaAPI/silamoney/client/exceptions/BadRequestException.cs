using System;

namespace SilaAPI.silamoney.client.exceptions
{
    /// <summary>
    /// Exception used when server returns status code 400 or 403.
    /// </summary>
    public class BadRequestException : Exception
    {
        /// <summary>
        /// BadRequestException constructor.
        /// </summary>
        /// <param name="message"></param>
        public BadRequestException(string message) : base(String.Format("Bad Request: {0}", message))
        {
        }
    }
}
