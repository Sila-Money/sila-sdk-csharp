using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class StatementsDeliveryAttempt
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime Created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "user_name", EmitDefaultValue = false)]
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "user_handle", EmitDefaultValue = false)]
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "account_type", EmitDefaultValue = false)]
        public string AccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message_id", EmitDefaultValue = false)]
        public string MessageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "statement_id", EmitDefaultValue = false)]
        public string StatementId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "notification_type", EmitDefaultValue = false)]
        public string NotificationType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "delivery_status", EmitDefaultValue = false)]
        public object DeliveryStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "sent_date", EmitDefaultValue = false)]
        public DateTime SentDate { get; set; }
    }
}
