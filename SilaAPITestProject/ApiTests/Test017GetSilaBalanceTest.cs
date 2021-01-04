using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test017GetSilaBalanceTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - GetSilaBalance - Successful balance retrieval")]
        public void Response200()
        {
            var user = DefaultConfig.SecondUser;
            var response = api.GetSilaBalance(user.CryptoAddress);
            var parsedResponse = (GetSilaBalanceResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(user.CryptoAddress, parsedResponse.Address);
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual(0, parsedResponse.SilaBalance);
        }

        [TestMethod("2 - GetSilaBalance - Unsuccessful balance retrieval")]
        public void Response400()
        {
            var response = api.GetSilaBalance("");

            Assert.AreEqual(400, response.StatusCode);
        }
    }
}
