using System;

namespace SilaAPI.silamoney.client.refactored.exceptions
{
    /// <summary>
    /// Exception thrown when sdk got a 403 response code.
    /// </summary>
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ForbiddenException(string message) : base(message) { }
    }
}