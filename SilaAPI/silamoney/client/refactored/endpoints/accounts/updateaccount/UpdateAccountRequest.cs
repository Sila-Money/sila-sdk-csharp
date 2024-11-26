namespace Sila.API.Client.Accounts
{
    #pragma warning disable CS1591
    public class UpdateAccountRequest
    {
        public string UserHandle { get; set; }
        public string UserPrivateKey { get; set; }
        public string AccountName { get; set; }
        public string NewAccountName { get; set; }
        public bool IsActive { get; set; } = true;
    }
    #pragma warning restore CS1591
}