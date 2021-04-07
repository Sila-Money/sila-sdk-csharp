using System;

namespace SilaAPI.silamoney.client.refactored.exceptions
{
    /// <summary>
    /// Exception thrown when sdk got a 401 response code.
    /// </summary>
    public class InvalidSignatureException : Exception
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public InvalidSignatureException(string message) : base(message) { }
    }
}