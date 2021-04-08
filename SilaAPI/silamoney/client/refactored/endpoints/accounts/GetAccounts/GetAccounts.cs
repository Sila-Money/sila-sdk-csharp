using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SilaAPI.Silamoney.Client.Refactored.Domain;
using SilaAPI.Silamoney.Client.Refactored.exceptions;
using SilaAPI.Silamoney.Client.Refactored.utils;
using SilaAPI.silamoney.client.util;

namespace SilaAPI.Silamoney.Client.Refactored.Endpoints.Accounts.GetAccounts
{
    public class GetAccounts : AbstractEndpoint
    {
        private static string endpoint = "/get_accounts";
        private GetAccounts() { }
        public static GetAccountsResponse Send(GetAccountsRequest request)
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new Header
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = AppHandle,
                UserHandle = request.UserHandle,
                Crypto = "ETH",
                Reference = UuidUtils.GetUuid(),
                Version = "0.2"
            });
            body.Add("message", "get_accounts_msg");

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
            headers = HeaderUtils.SetUserSignature(headers, serializedBody, request.UserPrivateKey);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            Console.WriteLine(response.Content);
            if ((int)response.StatusCode == 200){
                List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(response.Content); 
                return new GetAccountsResponse(accounts);
            }
            if ((int)response.StatusCode == 400)
                throw new BadRequestException(response.Content);
            if ((int)response.StatusCode == 401)
                throw new InvalidSignatureException(response.Content);

            throw new Exception(response.Content);
        }
    }
}