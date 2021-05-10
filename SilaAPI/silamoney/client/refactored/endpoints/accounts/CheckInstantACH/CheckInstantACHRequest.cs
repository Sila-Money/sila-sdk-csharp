namespace SilaAPI.Silamoney.Client.Refactored.Endpoints.Accounts.CheckInstantACH
{
    public class CheckInstantACHRequest
    {
        public string UserHandle { get; set; }
        public string UserPrivateKey { get; set; }
        public string AccountName { get; set; }
    }
}