using System;

namespace SilaAPI.silamoney.client.refactored.exceptions
{
    /// <summary>
    /// Exception thrown when sdk got a 400 response code.
    /// </summary>
    public class BadRequestException : Exception
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public BadRequestException(string message) : base(message) { }
    }
}