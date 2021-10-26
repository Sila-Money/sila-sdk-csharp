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
            var response = api.GetWebhooks(user.UserHandle, user.PrivateKey, searchFilters);
            var parsedResponse = (GetWebhooksResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Page);
            Assert.IsNotNull(parsedResponse.ReturnedCount);
            Assert.IsNotNull(parsedResponse.TotalCount);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Webhooks);
            Assert.IsNotNull(parsedResponse.Pagination);


            //ApiResponse<object> response = api.GetWebhooks(userHandle, userPrivateKey, searchFilters);
            //// searchFilters is optional 


            //// Success Response Object
            //Console.WriteLine(response.StatusCode); // 200            
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Success); // true
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Page); // Page number
            //Console.WriteLine(((GetWebhooksResponse)response.Data).ReturnedCount); // Returned count
            //Console.WriteLine(((GetWebhooksResponse)response.Data).TotalCount); // Total count.
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Status); // SUCCESS
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Pagination); // Pagination   

            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Attempts); // Attempts
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].CreatedEpoch); // Created epoch
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Delivered); // Delivered          
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].EndpointName); // Endpoint name
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].EndpointUrl); // Endpoint url
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].EventType); // Event type
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].LastUpdateEpoch); // Last update epoch
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].NextAttemptEpoch); // Next attempt epoch
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Processing); // Processing
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].UserHandle); // User handle   
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Uuid); // uuid   

            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Details.Account); // Account
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Details.AccountName); // Account Name
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Details.Entity); // Entity
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Details.KYC); // KYC
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Details.Transaction); // Transaction
            //Console.WriteLine(((GetWebhooksResponse)response.Data).Webhooks[0].Details.TransactionType); // TransactionType

        }

    }
}
