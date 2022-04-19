using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using static SilaAPI.silamoney.client.domain.SearchFilters;

namespace SilaApiTest
{
    [TestClass]
    public class Test033GetPaymentMethodsTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetPaymentMethods - Successfully retrieve of PaymentMethods")]
        public void T001_GetPaymentMethods()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetPaymentMethods(user.UserHandle, user.PrivateKey);
            var parsedResponse = (GetPaymentMethodsResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Pagination);
            Assert.IsNotNull(parsedResponse.PaymentMethods);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
