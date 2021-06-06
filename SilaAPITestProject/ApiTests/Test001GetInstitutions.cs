using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test001GetInstitutions
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetInstitutions - Successful get institutions")]
        public void T001Response200()
        {
            InstitutionSearchFilters searchFilters = new InstitutionSearchFilters{
                InstitutionName = "1st advantage bank"
            };
            var response = api.GetInstitutions(searchFilters);
            var parsedResponse = (GetInstitutionsResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
        }
    }
}
