using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// UpdateWalletMsg object used in the plaid same day auth endpoint
    /// </summary>
    public partial class UpdateWalletMsg : BaseMessageNoMsg
    {
        /// <summary>
        /// String field used in the UpdateWalletMsg object to save nickname
        /// </summary>
        [DataMember(Name = "nickname", EmitDefaultValue = false)]
        public string Nickname { get; set; }         
        /// <summary>
        /// Bool field used in the UpdateWalletMsg object to save status
        /// </summary>
        [DataMember(Name = "default", EmitDefaultValue = false)]
        public bool? IsDefault { get; set; }

        /// <summary>
        /// UpdateWalletMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="nickname"></param>
        /// <param name="isDefault"></param>        
        public UpdateWalletMsg(string userHandle,
            string authHandle,
            string nickname,
            bool? isDefault)
        {
            Header = new Header(userHandle, authHandle);
            Nickname = nickname;
            IsDefault = isDefault;
        }
    }
}
