using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test030DeleteCardTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - Delete card - Successful delete card")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.DeleteCard(user.UserHandle, user.PrivateKey, "visa");
            var parsedResponse = (DeleteCardResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);         
        }
    }
}

