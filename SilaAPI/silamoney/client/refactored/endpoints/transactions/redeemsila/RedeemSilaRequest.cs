using Sila.API.Client.Domain;
namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class RedeemSilaRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
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
        public string AccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProcessingType? ProcessingType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CardName { get; set; }
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
        public string MockWireAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TransactionIdempotencyId { get; set; }
    }

}
