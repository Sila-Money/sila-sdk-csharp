using Newtonsoft.Json;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckInstantACHResponse : BaseResponse
    {
        /// <summary>
        /// String field used in the BaseResponse object to save maximum_amount
        /// </summary>
        [JsonProperty("maximum_amount")]
        public string MaximumAmount { get; set; }

        /// <summary>
        /// error message entity
        /// </summary>
        [JsonProperty("qualification_details")]
        public QualificationDetails QualificationDetails { get; set; }
    }
}