using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;

namespace SilaApiTest
{
    [TestClass]
    public class Test012GetDocumentTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetDocument - Success Response")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetDocument(user.UserHandle, user.PrivateKey, DefaultConfig.DocumentId);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (string)response.Data;
            Assert.IsNotNull(parsedResponse);
            response.Headers.TryGetValue("Content-Type", out string contentType);
            Assert.AreEqual("image/png", contentType);
        }
    }
}
