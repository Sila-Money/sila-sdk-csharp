using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneData : RegistrationDataBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
