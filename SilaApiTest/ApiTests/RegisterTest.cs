using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.exceptions;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class RegisterTest
    {
        UserApi api = new UserApi(DefaultConfig.basePath, DefaultConfig.privateKey, DefaultConfig.appHandle);
        [TestInitialize]
        public void configuartion()
        {
            Thread thread = new Thread(createWebServer);
            thread.Start();
        }

        private void createWebServer()
        {
            string[] prefixes = new string[1];
            prefixes[0] = "http://localhost:8080/register/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void TestResponse200()
        {
            User user = ModelsUtilities.createUser();
            ApiResponse<object> response = api.Register(user);

            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).status);
            Assert.AreEqual(200, response.StatusCode);

        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException),"Bad request permited.")]
        public void TestResponse400()
        {
            User user = ModelsUtilities.createUser();
            user.userHandle = "";
            ApiResponse<object> response = api.Register(user);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid authsignature permited.")]
        public void TestResponse401()
        {
            User user = ModelsUtilities.createUser();
            user.userHandle= "wrongSignature.silamoney.eth";
            ApiResponse<object> response = api.Register(user);
        }
    }
}
