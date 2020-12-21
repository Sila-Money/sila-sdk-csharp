using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in GetEntity method.
    /// </summary>
    public class EntityPhone : EntityAudit
    {
        /// <summary>
        /// Phone property.
        /// </summary>
        /// <value>Phone</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// Indicates if the a confirmation message has been requested for this phone
        /// </summary>
        [JsonProperty("sms_confirmation_requested")]
        public bool SmsConfirmationRequested { get; set; }
        /// <summary>
        /// Indicates if the confirmation message has been confirmed by the user
        /// </summary>
        [JsonProperty("sms_confirmed")]
        public bool SmsConfirmed { get; set; }
        /// <summary>
        /// Indicates if this is set as the primary phone for the user
        /// </summary>
        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}