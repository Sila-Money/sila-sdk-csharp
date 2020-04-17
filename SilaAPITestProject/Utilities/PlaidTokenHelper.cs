using RestSharp;
using System;
using Newtonsoft.Json.Linq;

namespace SilaAPITestProject.Utilities
{
    class PlaidTokenHelper
    {
        private static RestClient _RestClient;
        private static RestClient RestClient
        {
            get
            {
                if (_RestClient == null) _RestClient = new RestClient("https://sandbox.plaid.com");
                return _RestClient;
            }
            set
            {
                _RestClient = value;
            }
        }

        private static RestRequest PrepareRequest(
            string path, object postBody,
            string contentType)
        {

            var request = new RestRequest(path, Method.POST);

            request.AddParameter(contentType, postBody, ParameterType.RequestBody);

            return request;
        }
        public static PlaidConfiguration getPlaidToken()
        {
            string postBody = "{\r\n" +
                            "    \"credentials\": {\r\n" +
                            "        \"username\": \"user_good\",\r\n" +
                            "        \"password\": \"pass_good\"\r\n" +
                            "    },\r\n" +
                            "    \"initial_products\": [\r\n" +
                            "        \"auth\"\r\n" +
                            "    ],\r\n" +
                            "    \"institution_id\": \"ins_3\",\r\n" +
                            "    \"public_key\": \"fa9dd19eb40982275785b09760ab79\"\r\n" +
                            "}";

            var request = PrepareRequest(
                "/link/item/create", postBody, "application/json");

            var response = RestClient.Execute(request);

            var json = response.Content;
            var jsonObject = JObject.Parse(json);

            Console.WriteLine(jsonObject);

            string plaidToken = jsonObject["public_token"].ToString();
            string accountId = jsonObject["accounts"][0]["account_id"].ToString();

            return new PlaidConfiguration(plaidToken, accountId);
        }

        public class PlaidConfiguration
        {
            public string Token { get;  }

            public string AccountId { get; }

            public PlaidConfiguration(string token, string accountId) {
                Token = token;
                AccountId = accountId;
            }
        }
    }
}
