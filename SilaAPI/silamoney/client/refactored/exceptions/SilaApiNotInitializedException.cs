using System;

namespace Sila.API.Client.Exceptions
{
    /// <summary>
    /// Exception thrown when trying to get SilaApi instance not initialized.
    /// </summary>
    public class SilaApiNotInitializedException : Exception
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public SilaApiNotInitializedException(string message) : base(message) { }
    }
}