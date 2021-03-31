using SilaAPI.silamoney.client.refactored.domain;

public class GetTransactionsRequest
{
    public string UserHandle { get; set; }
    public SearchFilters SearchFilters { get; set; }
}