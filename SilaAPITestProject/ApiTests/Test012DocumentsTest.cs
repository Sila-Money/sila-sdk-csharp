using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace SilaApiTest
{
    [TestClass]
    public class Test012DocumentsTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - UploadDocument - Successfully upload file")]
        public void Response200()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Resources{Path.DirectorySeparatorChar}logo-geko.png");
            var user = DefaultConfig.FirstUser;
            var documentType = DefaultConfig.DocumentTypes[0];
            var response = api.UploadDocument(user.UserHandle, user.PrivateKey, filepath, "logo-geko", "image/png", documentType.Name, documentType.IdentityType);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (DocumentResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ReferenceId);
            Assert.IsNotNull(parsedResponse.DocumentId);
            DefaultConfig.DocumentId = parsedResponse.DocumentId;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("2 - UploadDocument - Bad request")]
        public void Response400()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Resources{Path.DirectorySeparatorChar}logo-geko.png");
            var user = DefaultConfig.FirstUser;
            var documentType = DefaultConfig.DocumentTypes[0];
            var response = api.UploadDocument("", user.PrivateKey, filepath, "logo-geko", "image/png", documentType.Name, documentType.IdentityType);

            Assert.AreEqual(400, response.StatusCode);
            var parsedResponse = (BadRequestResponse)response.Data;
            Assert.IsFalse(parsedResponse.Success);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
        }

        [TestMethod("3 - UploadDocument - App signature failure")]
        public void Response403()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Resources{Path.DirectorySeparatorChar}logo-geko.png");
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
        }

        [TestMethod("4 - UploadDocuments - Successfully upload files")]
        public void Response201()
        {
            string filepath0 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Resources{Path.DirectorySeparatorChar}logo-geko.png");
            string filepath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Resources{Path.DirectorySeparatorChar}logo-geko.png");
            
            var documentType = DefaultConfig.DocumentTypes[0];

            List<UploadDocument> uploadDocument = new List<UploadDocument>();
            UploadDocument obj = new UploadDocument();
            obj.FileName = "logo-geko.png";
            obj.FilePath = filepath0;
            obj.Description = "test0";
            obj.DocumentType = documentType.Name;
            obj.MimeType = "image/png";
            obj.Name = "logo-geko";
            uploadDocument.Add(obj);

            obj = new UploadDocument();
            obj.FileName = "logo-geko.png";
            obj.FilePath = filepath1;
            obj.Description = "test1";
            obj.DocumentType = documentType.Name;
            obj.MimeType = "image/png";
            obj.Name = "logo-geko";
            uploadDocument.Add(obj);

            var user = DefaultConfig.FirstUser;
            var response = api.UploadDocuments(user.UserHandle, user.PrivateKey, uploadDocument);
            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (UploadDocumentsResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ReferenceId);
            Assert.IsNotNull(parsedResponse.DocumentId);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.UnsuccessfulUploads);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
