namespace Sila.API.Client
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractEndpoint
    {
        /// <summary>
        /// 
        /// </summary>
        public static ApiClient ApiClient = SilaAPI.GetInstance().ApiClient;
        /// <summary>
        /// 
        /// </summary>
        public static string AppHandle = SilaAPI.GetInstance().AppHandle;
        /// <summary>
        /// 
        /// </summary>
        public static string PrivateKey = SilaAPI.GetInstance().PrivateKey;
    }

}
