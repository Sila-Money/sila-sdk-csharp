using SilaAPI.silamoney.client.refactored.domain;

public class LinkAccountRequest
{
    public string UserHandle { get; set; }
    public string UserPrivateKey { get; set; }
    public string PlaidToken { get; set; }
    public string AccountName { get; set; }
    public string SelectedAccountId { get; set; }
    public string AccountNumber { get; set; }
    public string RoutingNumber { get; set; }
    public string AccountType { get; set; }
}