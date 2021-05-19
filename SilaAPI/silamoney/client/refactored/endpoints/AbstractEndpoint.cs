namespace Sila.API.Client
{
    public abstract class AbstractEndpoint
    {
        public static ApiClient ApiClient = SilaAPI.GetInstance().ApiClient;
        public static string AppHandle = SilaAPI.GetInstance().AppHandle;
        public static string PrivateKey = SilaAPI.GetInstance().PrivateKey;
    }
}