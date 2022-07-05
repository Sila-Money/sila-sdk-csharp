using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class TransferSilaRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DestinationHandle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DestinationAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DestinationWallet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SourceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DestinationId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float? Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Descriptor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BusinessUuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TransactionIdempotencyId { get; set; }
    }
}
