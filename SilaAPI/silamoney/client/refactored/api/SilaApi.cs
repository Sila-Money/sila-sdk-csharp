using Sila.API.Client.Exceptions;

namespace Sila.API
{
    /// <summary>
    /// Singleton class used to configure the api calls.
    /// </summary>
    public class SilaApi
    {
        private SilaApi(ApiClient apiClient, string appHandle, string privateKey)
        {
            this.AppHandle = appHandle;
            this.ApiClient = apiClient;
            this.PrivateKey = privateKey;
        }
        private static SilaApi _instance;
        public string AppHandle { get; private set; }
        public string PrivateKey { get; private set; }
        public ApiClient ApiClient { get; private set; }
        /// <summary>
        /// Initialize the SilaApi instance.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="appHandle"></param>
        /// <param name="privateKey"></param>
        public static void Init(Environments environment, string appHandle, string privateKey)
        {
            string basePath = environment == Environments.STAGING ? "https://stageapi.silamoney.com/0.2" :
                    environment == Environments.PRODUCTION ? "https://api.silamoney.com/0.2" :
                    "https://sandbox.silamoney.com/0.2";
            _instance = new SilaApi(
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
        public static SilaApi GetInstance()
        {
            if (_instance == null)
            {
                throw new SilaApiNotInitializedException("SilaApi not yet initialized. Run Init method before.");
            }
            return _instance;
        }
    }
}
