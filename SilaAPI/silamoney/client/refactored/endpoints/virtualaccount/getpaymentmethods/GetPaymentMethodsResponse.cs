using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.GetPaymentMethods
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
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_credit_enabled")]
        public bool AchCreditEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_debit_enabled")]
        public bool AchDebitEnabled { get; set; }
    }
}
