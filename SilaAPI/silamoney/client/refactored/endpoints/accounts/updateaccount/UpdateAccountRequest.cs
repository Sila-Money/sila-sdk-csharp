using SilaAPI.silamoney.client.refactored.domain;

public class UpdateAccountRequest
{
    public string UserHandle { get; set; }
    public string UserPrivateKey { get; set; }
    public string AccountName { get; set; }
    public string NewAccountName { get; set; }
}