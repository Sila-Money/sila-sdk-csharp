using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// LinkCardMsg object used in the link_card endpoint
    /// </summary>
    public partial class LinkCardMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "card_name", EmitDefaultValue = false)]
        public string CardName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "account_postal_code", EmitDefaultValue = false)]
        public string AccountPostalCode { get; set; }

        /// <summary>
        /// LinkCardMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="token"></param>
        /// <param name="appHandle"></param>
        /// <param name="cardName"></param>
        /// <param name="accountPostalCode"></param>                   
        public LinkCardMsg(string userHandle, string token, string appHandle, string accountPostalCode, string cardName)
        {
            Header = new Header(userHandle, appHandle);
            Token = token;
            MessageOption = Message.HeaderMsg;// LinkCardMsg;
            CardName = cardName;
            AccountPostalCode = accountPostalCode;
        }
    }
}
