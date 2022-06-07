using Sila.API.Client.Domain;
namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class ApproveWireRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Approve { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MockWireAccountName { get; set; }
    }
}
