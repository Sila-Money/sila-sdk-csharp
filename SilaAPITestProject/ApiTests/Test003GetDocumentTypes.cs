using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test003GetDocumentTypes
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetDocumentTypes - Successful get document types")]
        public void Response200()
        {
            var response = api.GetDocumentTypes();
            var parsedResponse = (DocumentTypesResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.DocumentTypes.Count > 0);
            Assert.IsNotNull(parsedResponse.DocumentTypes[0].Name);
            Assert.IsNotNull(parsedResponse.DocumentTypes[0].Label);
            Assert.IsNotNull(parsedResponse.DocumentTypes[0].IdentityType);

            DefaultConfig.DocumentTypes = parsedResponse.DocumentTypes;
        }

        [TestMethod("2 - GetDocumentTypes - Successful get document types with pagination")]
        public void Response200Pagination()
        {
            var response = api.GetDocumentTypes(1, 100);
            var parsedResponse = (DocumentTypesResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.DocumentTypes.Count > 20);
            Assert.IsNotNull(parsedResponse.DocumentTypes[0].Name);
            Assert.IsNotNull(parsedResponse.DocumentTypes[0].Label);
            Assert.IsNotNull(parsedResponse.DocumentTypes[0].IdentityType);
        }
    }
}
