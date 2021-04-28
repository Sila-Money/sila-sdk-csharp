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
            CheckPartnerKycRequest request = new CheckPartnerKycRequest
            {
                QueryAppHandle = "digital_geko_e2e_new",
                QueryUserHandle = "cross_app_check_partner"
            };

            var response = api.CheckPartnerKyc(request);
        }
    }
}
