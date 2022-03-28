using Sila.API.Client.Domain;
namespace Sila.API.Client.CloseVirtualAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class CloseVirtualAccountRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VirtualAccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountNumber { get; set; }
    }
}