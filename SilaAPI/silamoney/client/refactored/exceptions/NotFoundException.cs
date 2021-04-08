using System;

namespace SilaAPI.Silamoney.Client.Refactored.exceptions
{
    /// <summary>
    /// Exception thrown when sdk got a 404 response code.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public NotFoundException(string message) : base(message) { }
    }
}