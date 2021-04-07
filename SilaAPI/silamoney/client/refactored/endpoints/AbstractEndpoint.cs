using SilaAPI.silamoney.client.refactored.api;

namespace SilaAPI.silamoney.client.refactored.endpoints
{
    public abstract class AbstractEndpoint
    {
        public static ApiClient ApiClient = SilaApi.GetInstance().ApiClient;
        public static string AppHandle = SilaApi.GetInstance().AppHandle;
        public static string PrivateKey = SilaApi.GetInstance().PrivateKey;
    }
}