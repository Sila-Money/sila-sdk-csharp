using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test008DeleteRegistrationTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - DeleteRegistrationData - Success Response")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetEntity(user.UserHandle, user.PrivateKey);
            Assert.AreEqual(200, response.StatusCode);
            var entityResponse = (GetEntityResponse)response.Data;
            response = api.DeleteRegistrationData(user.UserHandle, user.PrivateKey, RegistrationData.Identity, entityResponse.Identities[0].Uuid);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (BaseResponseWithoutReference)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
        }
    }
}
