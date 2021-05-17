using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.util;
using Sila.API.Client.Domain;
using SilaAPI.silamoney.client.api;

namespace Sila.API.Client.Accounts.LinkAccount
{
    public class LinkAccount : AbstractEndpoint
    {
        private static string endpoint = "/link_account";
        private LinkAccount() { }
        public static ApiResponse<object> Send(LinkAccountRequest request)
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
            body.Add("plaid_token_type", request.PlaidTokenType);

            string serializedBody = SerializationUtil.Serialize(body);

            Console.WriteLine(serializedBody);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
            headers = HeaderUtils.SetUserSignature(headers, serializedBody, request.UserPrivateKey);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<LinkAccountResponse>(response);
        }
    }
}
