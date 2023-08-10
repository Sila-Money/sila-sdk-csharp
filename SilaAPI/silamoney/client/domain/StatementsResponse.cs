using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class StatementsResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public Pagination Pagination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[DataMember(Name = "delivery_attempts", EmitDefaultValue = false)]
        [JsonProperty("delivery_attempts")]
        public List<StatementsDeliveryAttempt> DeliveryAttempts { get; set; }
    }
}
