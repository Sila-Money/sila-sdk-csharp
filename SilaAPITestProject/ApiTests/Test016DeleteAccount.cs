using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test016DeleteAccount
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - Delete account - Successful delete account")]
        public void T020Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.DeleteAccount(user.UserHandle, user.PrivateKey, "unlink");
            var parsedResponse = (DeleteAccountResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
