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
        /// String field to accept Provider value in delete_card endpoint
        /// </summary>
        [DataMember(Name = "provider", EmitDefaultValue = false)]
        public string Provider { get; set; }
        /// <summary>
        ///
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="cardName"></param>
        /// <param name="provider"></param>
        public DeleteCardMsg(string userHandle, string appHandle, string cardName, string provider)
        {
            Header = new Header(userHandle, appHandle);
            CardName = cardName;
            Provider = provider;
        }
    }
}
