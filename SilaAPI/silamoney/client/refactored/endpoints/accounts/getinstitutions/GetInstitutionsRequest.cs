namespace Sila.API.Client.Accounts
{
    #pragma warning disable CS1591
    public class GetInstitutionsRequest
    {
        public string InstitutionName { get; set; }
        public string RoutingNumber { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
    #pragma warning restore CS1591
}