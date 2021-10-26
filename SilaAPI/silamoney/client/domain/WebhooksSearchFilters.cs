using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SearchFilters object used in the GetWebhooks method
    /// </summary>
    [DataContract]
    public partial class WebhooksSearchFilters
    {
        /// <summary>
        /// </summary>
        [DataMember(Name = "uuid", EmitDefaultValue = false)]
        public string Uuid { get; set; }
        /// <summary>
        /// </summary>
        [DataMember(Name = "delivered", EmitDefaultValue = false)]
        public bool? Delivered { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "sort_ascending", EmitDefaultValue = false)]
        public bool? SortAscending { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "event_type", EmitDefaultValue = false)]
        public string EventType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "endpoint_name", EmitDefaultValue = false)]
        public string EndpointName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "user_handle", EmitDefaultValue = false)]
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "start_epoch", EmitDefaultValue = false)]
        public int? StartEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "end_epoch", EmitDefaultValue = false)]
        public int? EndEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public int Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "per_page", EmitDefaultValue = false)]
        public int PerPage { get; set; }
    }
}
