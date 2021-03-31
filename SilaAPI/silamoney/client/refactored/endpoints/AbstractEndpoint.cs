using SilaAPI.silamoney.client.refactored.api;
public abstract class AbstractEndpoint
{
    public static ApiClient ApiClient = SilaApi.GetInstance().ApiClient;
    public static string AppHandle = SilaApi.GetInstance().AppHandle;
    public static string PrivateKey = SilaApi.GetInstance().PrivateKey;
}