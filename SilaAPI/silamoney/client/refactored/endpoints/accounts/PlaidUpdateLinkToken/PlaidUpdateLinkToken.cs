using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.util;

namespace Sila.API.Client.Accounts.PlaidUpdateLinkToken
{
    public class PlaidUpdateLinkToken : AbstractEndpoint
    {
        private static string endpoint = "/plaid_update_link_token";
        private PlaidUpdateLinkToken() { }
        public static ApiResponse<object> Send(PlaidUpdateLinkTokenRequest request)
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new Header
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = AppHandle,
                UserHandle = request.UserHandle
            });
            body.Add("account_name", request.AccountName);

            string serializedBody = SerializationUtil.Serialize(body);

            Console.WriteLine(serializedBody);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<PlaidUpdateLinkTokenResponse>(response);
        }
    }
}
