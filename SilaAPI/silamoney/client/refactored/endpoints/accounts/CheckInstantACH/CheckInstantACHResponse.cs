using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckInstantACHResponse : BaseResponse
    {
        /// <summary>
        /// String field used in the BaseResponse object to save qualification_details
        /// </summary>
        [JsonProperty("qualification_details")]
        public QualificationDetails QualificationDetails { get; set; }
    }
}