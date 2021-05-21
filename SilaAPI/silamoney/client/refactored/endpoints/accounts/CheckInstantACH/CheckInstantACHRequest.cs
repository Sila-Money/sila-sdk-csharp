namespace Sila.API.Client.Accounts
{
    public class CheckInstantACHRequest
    {
        public string UserHandle { get; set; }
        public string UserPrivateKey { get; set; }
        public string AccountName { get; set; }
    }
}