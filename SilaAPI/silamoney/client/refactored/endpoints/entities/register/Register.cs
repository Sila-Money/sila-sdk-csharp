using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.refactored.domain;
using SilaAPI.silamoney.client.refactored.exceptions;
using SilaAPI.silamoney.client.refactored.utils;
using SilaAPI.silamoney.client.util;

namespace SilaAPI.silamoney.client.refactored.endpoints.entities.register
{
    public class Register : AbstractEndpoint
    {
        private static string endpoint = "/register";
        private Register() { }
        public static RegisterResponse Send(RegisterRequest request)
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
            body.Add("device", request.Device);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            Console.WriteLine(response.Content);
            if ((int)response.StatusCode == 200)
                return JsonConvert.DeserializeObject<RegisterResponse>(response.Content);
            if ((int)response.StatusCode == 400)
                throw new BadRequestException(response.Content);
            if ((int)response.StatusCode == 401)
                throw new InvalidSignatureException(response.Content);

            throw new Exception(response.Content);
        }
    }
}