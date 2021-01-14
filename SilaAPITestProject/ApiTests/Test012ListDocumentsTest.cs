using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;

namespace SilaApiTest
{
    [TestClass]
    public class Test012ListDocumentsTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - ListDocuments - No filters")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.ListDocuments(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (ListDocumentsResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Documents.Count > 0);
            Assert.AreEqual(user.UserHandle.ToLower(), parsedResponse.Documents[0].UserHandle);
            Assert.AreEqual(DefaultConfig.DocumentId, parsedResponse.Documents[0].DocumentId);
            Assert.IsNotNull(parsedResponse.Documents[0].Name);
            Assert.IsNotNull(parsedResponse.Documents[0].Filename);
            Assert.IsNotNull(parsedResponse.Documents[0].Hash);
            Assert.IsNotNull(parsedResponse.Documents[0].Type);
            Assert.IsNotNull(parsedResponse.Documents[0].Size);
            Assert.IsNotNull(parsedResponse.Documents[0].Created);
            Assert.IsNotNull(parsedResponse.Pagination);
        }

        [TestMethod("1 - ListDocuments - All filters")]
        public void Response200AllParameters()
        {
            var user = DefaultConfig.FirstUser;
            var docTypes = new List<string> { DefaultConfig.DocumentTypes[0].Name };
            var response = api.ListDocuments(user.UserHandle, user.PrivateKey, DateTime.Today, DateTime.Today.AddDays(1), docTypes, "logo", "name", 1, 1, "asc");

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (ListDocumentsResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Documents.Count > 0);
            Assert.AreEqual(user.UserHandle.ToLower(), parsedResponse.Documents[0].UserHandle);
            Assert.AreEqual(DefaultConfig.DocumentId, parsedResponse.Documents[0].DocumentId);
            Assert.IsNotNull(parsedResponse.Documents[0].Name);
            Assert.IsNotNull(parsedResponse.Documents[0].Filename);
            Assert.IsNotNull(parsedResponse.Documents[0].Hash);
            Assert.IsNotNull(parsedResponse.Documents[0].Type);
            Assert.IsNotNull(parsedResponse.Documents[0].Size);
            Assert.IsNotNull(parsedResponse.Documents[0].Created);
            Assert.IsNotNull(parsedResponse.Pagination);
        }
    }
}
