using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class CancelTransactionRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TransactionId { get; set; }       
   
    }
}