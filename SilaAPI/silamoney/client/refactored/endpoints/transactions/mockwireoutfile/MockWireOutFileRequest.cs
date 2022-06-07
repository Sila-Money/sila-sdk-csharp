using Sila.API.Client.Domain;
namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class MockWireOutFileRequest
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
        public string WireStatus { get; set; } = null;
    }

}
