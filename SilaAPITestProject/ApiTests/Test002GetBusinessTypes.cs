using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test002GetBusinessTypes
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - GetBusinessTypes - Successful get types")]
        public void T019Response200()
        {
            var response = api.GetBusinessTypes();
            var parsedResponse = (BusinessTypesResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.BusinessTypes.Count > 0);
            Assert.IsNotNull(parsedResponse.BusinessTypes.First().Label);
            Assert.IsNotNull(parsedResponse.BusinessTypes.First().Name);
            Assert.IsNotNull(parsedResponse.BusinessTypes.First().Uuid);

            DefaultConfig.BusinessTypes = parsedResponse.BusinessTypes;
        }
    }
}
