using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// RetryWebhookMsg object used in the RetryWebhook endpoint
    /// </summary>
    [DataContract]
    public partial class RetryWebhookMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "event_uuid", EmitDefaultValue = false)]
        public string EventUuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="eventUuid"></param>
        public RetryWebhookMsg(string userHandle, string authHandle, string eventUuid)
        {
            this.Header = new Header(userHandle, authHandle);
            this.Message = "header_msg";
            this.EventUuid = eventUuid;
        }
    }
}

