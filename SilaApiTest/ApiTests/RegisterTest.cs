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
        readonly SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);
        [TestInitialize]
        public void Configuartion()
        {
            Thread thread = new Thread(CreateWebServer);
            thread.Start();
        }

        private void CreateWebServer()
        {
            string[] prefixes = new string[1];
            prefixes[0] = "http://localhost:8080/register/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void TestResponse200()
        {
            User user = ModelsUtilities.CreateUser();
            ApiResponse<object> response = api.Register(user);

            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).Status);
            Assert.AreEqual(200, response.StatusCode);

        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException), "Bad request permited.")]
        public void TestResponse400()
        {
            User user = ModelsUtilities.CreateUser();
            user.UserHandle = "";
            _ = api.Register(user);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid authsignature permited.")]
        public void TestResponse401()
        {
            User user = ModelsUtilities.CreateUser();
            user.UserHandle = "wrongSignature.silamoney.eth";
            _ = api.Register(user);
        }
    }
}
