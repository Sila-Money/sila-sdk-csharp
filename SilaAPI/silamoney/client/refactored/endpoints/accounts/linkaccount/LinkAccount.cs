using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.refactored.domain;
using SilaAPI.silamoney.client.refactored.exceptions;
using SilaAPI.silamoney.client.refactored.utils;
using SilaAPI.silamoney.client.util;

namespace SilaAPI.silamoney.client.refactored.endpoints.accounts.linkaccount
{
    public class LinkAccount : AbstractEndpoint
    {
        private static string endpoint = "/link_account";
        private LinkAccount() { }
        public static LinkAccountResponse Send(LinkAccountRequest request)
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
            body.Add("account_name", request.AccountName);
            body.Add("account_number", request.AccountNumber);
            body.Add("routing_number", request.RoutingNumber);
            body.Add("account_type", request.AccountType);
            body.Add("plaid_token", request.PlaidToken);
            body.Add("selected_account_id", request.SelectedAccountId);

            string serializedBody = SerializationUtil.Serialize(body);

            Console.WriteLine(serializedBody);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
            headers = HeaderUtils.SetUserSignature(headers, serializedBody, request.UserPrivateKey);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            Console.WriteLine(response.Content);
            if ((int)response.StatusCode == 200 || (int)response.StatusCode == 202)
                return JsonConvert.DeserializeObject<LinkAccountResponse>(response.Content);
            if ((int)response.StatusCode == 400)
                throw new BadRequestException(response.Content);
            if ((int)response.StatusCode == 401)
                throw new InvalidSignatureException(response.Content);
            if ((int)response.StatusCode == 403)
                throw new ForbiddenException(response.Content);

            throw new Exception(response.Content);
        }
    }
}
