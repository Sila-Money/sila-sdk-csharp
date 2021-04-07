using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.refactored.domain;
using SilaAPI.silamoney.client.refactored.exceptions;
using SilaAPI.silamoney.client.refactored.utils;
using SilaAPI.silamoney.client.util;

namespace SilaAPI.silamoney.client.refactored.endpoints.entities.checkpartnerkyc
{
    public class CheckPartnerKyc : AbstractEndpoint
    {
        private static string endpoint = "/check_partner_kyc";
        private CheckPartnerKyc() { }
        public static CheckPartnerKycResponse Send(CheckPartnerKycRequest request)
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new Header
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = AppHandle,
                Crypto = "ETH",
                Reference = UuidUtils.GetUuid(),
                Version = "0.2"
            });
            body.Add("query_app_handle", request.QueryAppHandle);
            body.Add("query_user_handle", request.QueryUserHandle);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            Console.WriteLine(response.Content);
            if ((int)response.StatusCode == 200)
                return JsonConvert.DeserializeObject<CheckPartnerKycResponse>(response.Content);
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