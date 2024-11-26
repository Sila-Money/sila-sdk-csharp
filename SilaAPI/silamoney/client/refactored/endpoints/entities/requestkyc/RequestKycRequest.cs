namespace Sila.API.Client.Entities
{
    #pragma warning disable CS1591
    public class RequestKycRequest
    {
        public string UserHandle { get; set; }
        public string UserPrivateKey { get; set; }
        public string KycLevel { get; set; }
    }
    #pragma warning restore CS1591
}