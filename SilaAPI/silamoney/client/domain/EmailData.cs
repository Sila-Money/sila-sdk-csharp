using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <sumary>
    ///
    /// </sumary>
    public class EmailData : RegistrationDataBase
    {
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
