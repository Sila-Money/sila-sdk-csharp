using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterResponse : BaseResponse
    {
        /// <summary>
        ///  String field used in the RegisterResponse object to save BusinessUuid
        /// </summary>
        /// <value>BusinessUuid</value>
        [JsonProperty("business_uuid")]
        public string BusinessUuid { get; private set; }
    }
}