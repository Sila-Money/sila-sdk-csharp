using System;
using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{   /// <summary>
    /// DeleteTransactionMsg object used in the create_test_virtual_account_ach_transaction endpoint
    /// </summary>
    public partial class CreateTestVirtualAccountAchTransactionMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public int Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "virtual_account_number", EmitDefaultValue = false)]
        public string VirtualAccountNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "tran_code", EmitDefaultValue = false)]
        public int TranCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "effective_date", EmitDefaultValue = false)]
        public string EffectiveDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "entity_name", EmitDefaultValue = false)]
        public string EntityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ced", EmitDefaultValue = false)]
        public string Ced { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ach_name", EmitDefaultValue = false)]
        public string AchName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="amount"></param>
        /// <param name="virtualAccountNumber"></param>
        /// <param name="tranCode"></param>
        /// <param name="entityName"></param>
        /// <param name="effectiveDate"></param>
        /// <param name="ced"></param>
        /// <param name="achName"></param>
        public CreateTestVirtualAccountAchTransactionMsg(string userHandle, string appHandle, int amount, string virtualAccountNumber, int tranCode, string entityName, DateTime? effectiveDate, string ced, string achName)
        {
            Header = new Header(userHandle, appHandle);
            Amount = amount;
            VirtualAccountNumber = virtualAccountNumber;
            TranCode = tranCode;
            EffectiveDate = effectiveDate.HasValue ? effectiveDate.Value.ToString("yyyy-MM-dd") : null;
            EntityName = entityName;
            Ced = ced;
            AchName = achName;
        }
    }
}
