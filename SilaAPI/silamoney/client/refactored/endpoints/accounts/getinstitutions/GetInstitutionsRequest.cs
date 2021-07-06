namespace Sila.API.Client.Accounts
{
    public class GetInstitutionsRequest
    {
        public string InstitutionName { get; set; }
        public string RoutingNumber { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}