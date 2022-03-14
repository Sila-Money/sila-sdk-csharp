using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test016_CheckInstantACHTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - Check Instant ACH")]
        public void T001_CheckInstantACH()
        {
            var response = api.CheckInstantACH(
                userHandle: DefaultConfig.FirstUser.UserHandle,
                userPrivateKey: DefaultConfig.FirstUser.PrivateKey,
                accountName: "default"
            );

            var parsedResponse = (CheckInstantACHResponse)response.Data;

            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.QualificationDetails.SmsOptIn);
        }
    }
}
