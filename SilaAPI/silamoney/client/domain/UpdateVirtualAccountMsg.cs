using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVirtualAccountMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "virtual_account_id", EmitDefaultValue = false)]
        public string VirtualAccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "virtual_account_name", EmitDefaultValue = false)]
        public string VirtualAccountName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "active", EmitDefaultValue = false)]
        public bool? Active { get; set; }

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
    /// 
    /// </summary>
    /// <param name="userHandle"></param>
    /// <param name="appHandle"></param>
    /// <param name="virtualAccountId"></param>
    /// <param name="virtualAccountName"></param>
    /// <param name="achCreditEnabled"></param>
    /// <param name="achDebitEnabled"></param>
    /// <param name="active"></param>
        public UpdateVirtualAccountMsg(string userHandle, string appHandle, string virtualAccountId, string virtualAccountName, bool? achCreditEnabled, bool? achDebitEnabled, bool? active = true)
        {
            Header = new Header(userHandle, appHandle);
            VirtualAccountId = virtualAccountId;
            VirtualAccountName = virtualAccountName;
            Active = active;
            AchCreditEnabled = achCreditEnabled;
            AchDebitEnabled = achDebitEnabled;
        }
    }
}
