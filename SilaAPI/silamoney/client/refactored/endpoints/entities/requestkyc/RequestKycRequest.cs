namespace SilaAPI.silamoney.client.refactored.endpoints.entities.requestkyc
{
    public class RequestKycRequest
    {
        public string UserHandle { get; set; }
        public string UserPrivateKey { get; set; }
        public string KycLevel { get; set; }
    }
}