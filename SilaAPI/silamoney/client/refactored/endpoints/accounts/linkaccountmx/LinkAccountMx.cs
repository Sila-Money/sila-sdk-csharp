using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkAccountMx : AbstractEndpoint
    {
        private static string endpoint = "/link_account";
        private LinkAccountMx() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(LinkAccountMxRequest request)
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
            body.Add("provider", request.Provider);
            body.Add("provider_token_type", request.ProviderToken);
            body.Add("provider_token", request.ProviderTokenType);
            body.Add("selected_account_id", request.AccountId);

            string serializedBody = SerializationUtil.Serialize(body);

            Console.WriteLine(serializedBody);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
            headers = HeaderUtils.SetUserSignature(headers, serializedBody, request.UserPrivateKey);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<LinkAccountMxResponse>(response);
        }
    }
}
