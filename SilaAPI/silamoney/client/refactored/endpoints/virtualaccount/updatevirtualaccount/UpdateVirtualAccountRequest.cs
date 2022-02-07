using Sila.API.Client.Domain;
namespace Sila.API.Client.UpdateVirtualAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVirtualAccountRequest
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
        public string VirtualAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? Active { get; set; }
    }
}