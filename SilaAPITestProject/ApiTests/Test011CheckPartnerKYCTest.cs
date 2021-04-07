using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.refactored.api;
using SilaAPI.silamoney.client.refactored.endpoints.entities.checkpartnerkyc;

namespace SilaApiTest
{
    [TestClass]
    public class Test011_CheckPartnerKYCTest
    {
        [TestInitialize]
        public void TestInitialize() {
            SilaApi.Init(Environments.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
        }

        [TestMethod("1 - Check Partner Kyc")]
        public void TestResponse200()
        {
            try
            {
                CheckPartnerKycRequest request = new CheckPartnerKycRequest{
                    QueryAppHandle = "digital_geko_e2e_new",
                    QueryUserHandle = "cross_app_check_partner"
                };

                CheckPartnerKycResponse response = CheckPartnerKyc.Send(request);
            }
            catch (System.Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Handle cross_app_check_partner"));
            }
        }
    }
}
