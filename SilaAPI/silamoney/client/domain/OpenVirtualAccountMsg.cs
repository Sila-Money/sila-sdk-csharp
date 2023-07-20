using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{   /// <summary>
    /// DeleteTransactionMsg object used in the open_virtual_account endpoint
    /// </summary>
    public partial class OpenVirtualAccountMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "virtual_account_name", EmitDefaultValue = false)]
        public string VirtualAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ach_credit_enabled", EmitDefaultValue = false)]
        public bool? AchCreditEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ach_debit_enabled", EmitDefaultValue = false)]
        public bool? AchDebitEnabled { get; set; }
        /// <summary>
        /// Boolean field of statements_enabled.
        /// </summary>
        [DataMember(Name = "statements_enabled", EmitDefaultValue = false)]
        public bool? StatementsEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="virtualAccountName"></param>
        /// <param name="achCreditEnabled"></param>
        /// <param name="achDebitEnabled"></param>
        /// <param name="statementsEnabled"></param>
        public OpenVirtualAccountMsg(string userHandle, string appHandle, string virtualAccountName, bool? achCreditEnabled, bool? achDebitEnabled, bool? statementsEnabled = null)
        {
            Header = new Header(userHandle, appHandle);
            VirtualAccountName = virtualAccountName;
            AchCreditEnabled = achCreditEnabled;
            AchDebitEnabled = achDebitEnabled;
            StatementsEnabled = statementsEnabled;
        }
    }
}
