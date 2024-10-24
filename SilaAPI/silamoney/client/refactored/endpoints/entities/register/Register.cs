using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;

namespace Sila.API.Client.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Register : AbstractEndpoint
    {
        private static string endpoint = "/register";

        /// <summary>
        /// 
        /// </summary>
        private Register() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(RegisterRequest request)
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new Header
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = AppHandle,
                Crypto = "ETH",
                Reference = UuidUtils.GetUuid(),
                UserHandle = request.UserHandle,
                Version = "0.2"
            });
            body.Add("message", "entity_msg");
            body.Add("address", request.Address);
            body.Add("identity", request.Identity);
            body.Add("contact", request.Contact);
            body.Add("crypto_entry", request.CryptoEntry);
            body.Add("entity", request.Entity);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<RegisterResponse>(response);
        }
    }
}