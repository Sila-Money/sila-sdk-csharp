using Newtonsoft.Json;
namespace SilaAPI.silamoney.client.domain
{
    public class CheckInstantACHResponse : BaseResponse
    {
        /// <summary>
        /// String field used in the BaseResponse object to save reference
        /// </summary>
        [JsonProperty("maximum_amount")]
        public string MaximumAmount { get; set; }

    }
}