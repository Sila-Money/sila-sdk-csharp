using Sila.API.Client.Domain;
namespace Sila.API.Client.OpenVirtualAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenVirtualAccountRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VirtualAccountName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? AchCreditEnabled { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public bool? AchDebitEnabled { get; set; } = null;
    }
}