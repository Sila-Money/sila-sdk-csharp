namespace Sila.API.Client.Entities
{
    public class RequestKycRequest
    {
        public string UserHandle { get; set; }
        public string UserPrivateKey { get; set; }
        public string KycLevel { get; set; }
    }
}