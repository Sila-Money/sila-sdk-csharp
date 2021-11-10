using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// LinkCardMsg object used in the link_card endpoint
    /// </summary>
    public partial class DeleteCardMsg : BaseMessage
    {  
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "card_name", EmitDefaultValue = false)]
        public string CardName { get; set; }
     
        /// <summary>
        /// LinkCardMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="publicToken"></param>
        /// <param name="appHandle"></param>
        /// <param name="cardName"></param>
        /// <param name="accountPostalCode"></param>                   
        public DeleteCardMsg(string userHandle, string appHandle, string cardName)
        {
            Header = new Header(userHandle, appHandle);
            CardName = cardName;
        }
    }
}
