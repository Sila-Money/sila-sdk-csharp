using Sila.API.Client.Domain;

namespace Sila.API.Client.Cards
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCardRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CardName { get; set; }
    }
}