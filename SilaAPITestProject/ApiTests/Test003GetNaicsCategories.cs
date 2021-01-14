using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test003GetNaicsCategories
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetNaicsCategoires - Successful get naics categories")]
        public void T021Response200()
        {
            var response = api.GetNaicsCategories();
            var parsedResponse = (NaicsCategoriesResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.NaicsCategories.Count > 0);
            Assert.IsNotNull(parsedResponse.NaicsCategories.First().Key);
            Assert.IsNotNull(parsedResponse.NaicsCategories.First().Value);

            DefaultConfig.NaicsCategories = parsedResponse.NaicsCategories;
        }
    }
}
