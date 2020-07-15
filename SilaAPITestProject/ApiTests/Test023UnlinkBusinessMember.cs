﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test023UnlinkBusinessMember
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - UnlinkBusinessMember - Successful unlink administrator")]
        public void T022Response200Administrator()
        {
            var businessRole = DefaultConfig.BusinessRole("administrator");
            var response = api.UnlinkBusinessMember(
                DefaultConfig.SecondUser.UserHandle,
                DefaultConfig.SecondUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey,
                businessRole
            );

            var parsedResponse = (LinkOperationResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(businessRole.Name, parsedResponse.Role);
            Assert.IsNotNull(parsedResponse.Message);
        }
    }
}