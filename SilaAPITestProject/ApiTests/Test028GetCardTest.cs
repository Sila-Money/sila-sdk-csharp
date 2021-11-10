using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test028GetCardTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetCard - Success Response")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetCards(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (GetCardsResponse)response.Data;
            Assert.IsNotNull(parsedResponse);
            Assert.IsNotNull(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Cards);
            Assert.IsNotNull(parsedResponse.Pagination);
            Assert.IsNotNull(parsedResponse.Status);
        }
    }
}
