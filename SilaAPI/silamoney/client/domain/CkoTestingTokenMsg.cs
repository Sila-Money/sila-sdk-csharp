using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetWalletStatementDataMsg object used in the get_wallet_statement_data endpoint
    /// </summary>
    [DataContract]
    public partial class CkoTestingTokenMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        /// 
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cko_public_key")]
        public string CkoPublicKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="message"></param>
        /// 
        public CkoTestingTokenMsg(string userHandle, string authHandle, Message message = null)
        {
            this.Header = new Header(userHandle, authHandle);
            this.CardNumber = message.CardNumber;
            this.ExpiryMonth = message.ExpiryMonth;
            this.ExpiryYear = message.ExpiryYear;
            this.CkoPublicKey = message.CkoPublicKey;
        }
    }
}
