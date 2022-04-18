using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test031GetWebhooksTest
    {
        SilaApi api = DefaultConfig.Client;
        string eventUuid = "";
        
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
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
            if (parsedResponse.Webhooks.Count > 0)
            {
                eventUuid = parsedResponse.Webhooks[0].Uuid;
            }
        }

        [TestMethod("2 - RetryWebhook - Successfully retrieve of retry webhook")]
        public void T002_RetryWebhook()
        {
            if (!string.IsNullOrWhiteSpace(eventUuid))
            {
                var user = DefaultConfig.FirstUser;
                var response = api.RetryWebhook(user.UserHandle, eventUuid);
                var parsedResponse = (BaseResponse)response.Data;
                Assert.IsTrue(parsedResponse.Success);
                Assert.IsNotNull(parsedResponse.Message);
                Assert.IsNotNull(parsedResponse.Status);
                Assert.IsNotNull(parsedResponse.ResponseTimeMs);
            }
        }
    }
}
