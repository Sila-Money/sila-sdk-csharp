using SilaAPI.Silamoney.Client.Refactored.Api;

namespace SilaAPI.Silamoney.Client.Refactored.Endpoints
{
    public abstract class AbstractEndpoint
    {
        public static ApiClient ApiClient = SilaApi.GetInstance().ApiClient;
        public static string AppHandle = SilaApi.GetInstance().AppHandle;
        public static string PrivateKey = SilaApi.GetInstance().PrivateKey;
    }
}