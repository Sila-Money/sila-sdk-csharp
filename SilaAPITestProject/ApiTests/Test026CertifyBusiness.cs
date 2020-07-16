using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test026CertifyBusiness
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - CertifyBusiness - Successful certify business")]
        public void Response200()
        {
            var response = api.CertifyBusiness(
                DefaultConfig.FirstUser.UserHandle, 
                DefaultConfig.FirstUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey
            );

            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsTrue(response.success);
        }
    }
}
