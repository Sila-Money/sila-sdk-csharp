using Sila.API.Client.Exceptions;

namespace Sila.API.Client
{
    #pragma warning disable CS1591
    /// <summary>
    /// Singleton class used to configure the api calls.
    /// </summary>
    public class SilaAPI
    {
        private SilaAPI(ApiClient apiClient, string appHandle, string privateKey)
        {
            this.AppHandle = appHandle;
            this.ApiClient = apiClient;
            this.PrivateKey = privateKey;
        }
        private static SilaAPI _instance;
        public string AppHandle { get; private set; }
        public string PrivateKey { get; private set; }
        public ApiClient ApiClient { get; private set; }
        /// <summary>
        /// Initialize the SilaAPI instance.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="appHandle"></param>
        /// <param name="privateKey"></param>
        public static void Init(Environments environment, string appHandle, string privateKey)
        {
            string basePath = environment == Environments.PRODUCTION ? "https://api.silamoney.com/0.2" :
                    "https://sandbox.silamoney.com/0.2";
            _instance = new SilaAPI(
                apiClient: new ApiClient(
                    basePath: basePath
                ),
                appHandle: appHandle,
                privateKey: privateKey
            );
        }
        /// <summary>
        /// Gets the Sila Api instance.
        /// </summary>
        /// <returns></returns>
        public static SilaAPI GetInstance()
        {
            if (_instance == null)
            {
                throw new SilaApiNotInitializedException("SilaAPI not yet initialized. Run Init method before.");
            }
            return _instance;
        }
    }
    #pragma warning restore CS1591
}