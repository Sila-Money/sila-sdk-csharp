using Sila.API.Client.Domain;

namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Identity Identity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Contact Contact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CryptoEntry CryptoEntry { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Entity Entity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Device Device { get; set; }
    }
}