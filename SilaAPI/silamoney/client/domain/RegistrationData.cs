namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class RegistrationData
    {
        private readonly string url;
        /// <summary>
        /// 
        /// </summary>
        public static readonly RegistrationData Email = new RegistrationData("email");
        /// <summary>
        /// 
        /// </summary>
        public static readonly RegistrationData Phone = new RegistrationData("phone");
        /// <summary>
        /// 
        /// </summary>
        public static readonly RegistrationData Identity = new RegistrationData("identity");
        /// <summary>
        /// 
        /// </summary>
        public static readonly RegistrationData Address = new RegistrationData("address");
        /// <summary>
        /// 
        /// </summary>
        public static readonly RegistrationData Entity = new RegistrationData("entity");
        /// <summary>
        /// 
        /// </summary>
        public static readonly RegistrationData Device = new RegistrationData("device");

        private RegistrationData(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get { return url; } }
    }
}
