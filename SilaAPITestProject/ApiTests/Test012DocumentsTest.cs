using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;

namespace SilaApiTest
{
    [TestClass]
    public class Test012DocumentsTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - UploadDocument - Successfully upload file")]
        public void Response200()
        {
            string filepath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Resources\\logo-geko.png";
            var user = DefaultConfig.FirstUser;
            var documentType = DefaultConfig.DocumentTypes[0];
            var response = api.UploadDocument(user.UserHandle, user.PrivateKey, filepath, "logo-geko", "image/png", documentType.Name, documentType.IdentityType);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (DocumentResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("File uploaded successfully"));
            Assert.IsNotNull(parsedResponse.ReferenceId);
            Assert.IsNotNull(parsedResponse.DocumentId);
        }

        [TestMethod("2 - UploadDocument - Bad request")]
        public void Response400()
        {
            string filepath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Resources\\logo-geko.png";
            var user = DefaultConfig.FirstUser;
            var documentType = DefaultConfig.DocumentTypes[0];
            var response = api.UploadDocument("", user.PrivateKey, filepath, "logo-geko", "image/png", documentType.Name, documentType.IdentityType);

            Assert.AreEqual(400, response.StatusCode);
            var parsedResponse = (BadRequestResponse)response.Data;
            Assert.IsFalse(parsedResponse.Success);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Bad request"));
        }

        [TestMethod("3 - UploadDocument - App signature failure")]
        public void Response403()
        {
            string filepath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Resources\\logo-geko.png";
            var user = DefaultConfig.FirstUser;
            var documentType = DefaultConfig.DocumentTypes[0];
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.UploadDocument(user.UserHandle, user.PrivateKey, filepath, "logo-geko", "image/png", documentType.Name, documentType.IdentityType);

            Assert.AreEqual(403, response.StatusCode);
            var parsedResponse = (BaseResponse)response.Data;
            Assert.IsFalse(parsedResponse.Success);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Failed to authenticate app signature"));
        }
    }
}
