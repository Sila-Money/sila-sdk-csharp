using Sila.API.Client.Domain;

namespace Sila.API.Client.Cards
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkCardRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserPrivateKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountPostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CardName { get; set; } = null;
        /// <summary>
        ///
        ///</summary>
        public string Provider { get; set; } = null;

    }
}