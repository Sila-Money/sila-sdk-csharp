using Newtonsoft.Json;
using System.Collections.Generic;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetPaymentMethodsResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("payment_methods")]
        public List<PaymentMethods> PaymentMethods { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
