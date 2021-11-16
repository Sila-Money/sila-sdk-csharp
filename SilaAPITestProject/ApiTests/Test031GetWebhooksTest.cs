using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test031GetWebhooksTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetWebhooks - Successfully retrieve of Webhooks")]
        public void T001_GetWebhooks()
        {         
            var user = DefaultConfig.FirstUser;

            WebhooksSearchFilters searchFilters = new WebhooksSearchFilters();
            var response = api.GetWebhooks(user.UserHandle, searchFilters);
            var parsedResponse = (GetWebhooksResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Page);
            Assert.IsNotNull(parsedResponse.ReturnedCount);
            Assert.IsNotNull(parsedResponse.TotalCount);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Webhooks);
            Assert.IsNotNull(parsedResponse.Pagination);
        }
    }
}
