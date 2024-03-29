﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test001GetBusinessRoles
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetBusinessRoles - Successful get roles")]
        public void T020Response200()
        {
            var response = api.GetBusinessRoles();
            var parsedResponse = (BusinessRolesResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.BusinessRoles.Count > 0);
            Assert.IsNotNull(parsedResponse.BusinessRoles.First().Label);
            Assert.IsNotNull(parsedResponse.BusinessRoles.First().Name);
            Assert.IsNotNull(parsedResponse.BusinessRoles.First().Uuid);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);

            DefaultConfig.BusinessRoles = parsedResponse.BusinessRoles;
        }
    }
}
