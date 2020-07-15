﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test022LinkBusinessMember
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - LinkBusinessMember - Successful link administrator")]
        public void T022Response200Administrator()
        {
            var businessRole = DefaultConfig.BusinessRole("administrator");
            var response = api.LinkBusinessMember(
                DefaultConfig.FirstUser.UserHandle,
                DefaultConfig.FirstUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey,
                businessRole, "test details"
            );

            var parsedResponse = (LinkOperationResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("test details", parsedResponse.Details);
            Assert.AreEqual(businessRole.Name, parsedResponse.Role);
            Assert.IsNotNull(parsedResponse.Message);

            businessRole = DefaultConfig.BusinessRole("controlling_officer");
            response = api.LinkBusinessMember(
                DefaultConfig.FirstUser.UserHandle,
                DefaultConfig.FirstUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey,
                businessRole, "test details"
            );

            parsedResponse = (LinkOperationResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("test details", parsedResponse.Details);
            Assert.AreEqual(businessRole.Name, parsedResponse.Role);
            Assert.IsNotNull(parsedResponse.Message);
        }

        [TestMethod("1 - LinkBusinessMember - Successful link second administrator")]
        public void T022Response200SecondAdministrator()
        {
            var businessRole = DefaultConfig.BusinessRole("administrator");
            var response = api.LinkBusinessMember(
                DefaultConfig.SecondUser.UserHandle,
                DefaultConfig.SecondUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey,
                businessRole, "test details"
            );

            var parsedResponse = (LinkOperationResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("test details", parsedResponse.Details);
            Assert.AreEqual(businessRole.Name, parsedResponse.Role);
            Assert.IsNotNull(parsedResponse.Message);
        }
    }
}