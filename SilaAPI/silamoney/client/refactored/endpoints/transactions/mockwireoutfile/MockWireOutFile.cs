using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using Sila.API.Client;
namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class MockWireOutFile : AbstractEndpoint
    {
        private static string endpoint = "/mock_wire_out_file";
        private MockWireOutFile() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(MockWireOutFileRequest request)
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
            body.Add("wire_status", request.WireStatus);
            string serializedBody = SerializationUtil.Serialize(body);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");
            return ResponseUtils.PrepareResponse<MockWireOutFileResponse>(response);
        }
    }

}
