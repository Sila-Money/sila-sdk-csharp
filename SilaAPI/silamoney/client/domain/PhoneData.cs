using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneData : RegistrationDataBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sms_confirmation_requested")]
        public bool SmsConfirmationRequested { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sms_confirmed")]
        public bool SmsConfirmed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}
