using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test004GetEntities
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - GetEntities - Successful GetEntities")]
        public void T022Response200()
        {
            var response = api.GetEntities();

            var parsedResponse = (GetEntitiesResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Entities.Individuals.Count > 0);
            Assert.IsNotNull(parsedResponse.Entities.Individuals.First().Created);
            Assert.IsNotNull(parsedResponse.Entities.Individuals.First().Handle);
            Assert.IsNotNull(parsedResponse.Entities.Individuals.First().Status);
            Assert.IsTrue(parsedResponse.Entities.Individuals.First().BlockchainAddresses.Count > 0);
            Assert.IsNotNull(parsedResponse.Entities.Businesses.First().Created);
            Assert.IsNotNull(parsedResponse.Entities.Businesses.First().FullName);
            Assert.IsNotNull(parsedResponse.Entities.Businesses.First().Handle);
            Assert.IsNotNull(parsedResponse.Entities.Businesses.First().BusinessType);
            Assert.IsNotNull(parsedResponse.Entities.Businesses.First().Dba);
            Assert.IsNotNull(parsedResponse.Entities.Businesses.First().Uuid);
            Assert.IsTrue(parsedResponse.Entities.Businesses.First().BlockchainAddresses.Count > 0);

        }
    }
}
