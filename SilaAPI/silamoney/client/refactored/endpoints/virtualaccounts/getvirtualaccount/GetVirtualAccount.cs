using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.util;

namespace Sila.API.Client.VirtualAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public class GetVirtualAccount : AbstractEndpoint
    {
        private static string endpoint = "/get_virtual_account";
        private GetVirtualAccount() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(GetVirtualAccountRequest request)
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

            body.Add("virtual_account_id", request.VirtualAccountId);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<GetVirtualAccountResponse>(response);
        }
    }
}
