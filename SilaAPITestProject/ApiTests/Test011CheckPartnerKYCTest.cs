using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test011_CheckPartnerKYCTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - Check Partner Kyc")]
        public void TestResponse200()
        {
            var response = api.CheckPartnerKyc(
                queryAppHandle: "digital_geko_e2e_new",
                queryUserHandle: "cross_app_check_partner");
        }
    }
}
