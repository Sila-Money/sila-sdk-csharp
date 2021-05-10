using System;

namespace Sila.API.Client.Exceptions
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