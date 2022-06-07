using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.util;
using Sila.API.Client;
using SilaAPI.silamoney.client.api;
namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class ApproveWire : AbstractEndpoint
    {
        private static string endpoint = "/approve_wire";
        private ApproveWire() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(ApproveWireRequest request)
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
            body.Add("transaction_id", request.TransactionId);
            body.Add("approve", request.Approve);
            if (!string.IsNullOrWhiteSpace(request.Notes))
            {
                body.Add("notes", request.Notes);
            }
            if (!string.IsNullOrWhiteSpace(request.MockWireAccountName))
            {
                body.Add("mock_wire_account_name", request.MockWireAccountName);
            }
            string serializedBody = SerializationUtil.Serialize(body);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");
            return ResponseUtils.PrepareResponse<ApproveWireResponse>(response);
        }
    }
}
