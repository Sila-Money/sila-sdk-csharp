using Sila.API.Client.Domain;
namespace Sila.API.Client.VirtualAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateTestVirtualAccountAchTransactionRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VirtualAccountNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TranCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EffectiveDate { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ced { get; set; } = "PAYROLL";
        /// <summary>
        /// 
        /// </summary>
        public string AchName { get; set; } = "SILA INC";
    }
}