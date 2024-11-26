using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;

namespace Sila.API.Client.Entities
{
    #pragma warning disable CS1591
    public class CheckPartnerKyc : AbstractEndpoint
    {
        private static string endpoint = "/check_partner_kyc";
        private CheckPartnerKyc() { }
        public static ApiResponse<object> Send(CheckPartnerKycRequest request)
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

            return ResponseUtils.PrepareResponse<CheckPartnerKycResponse>(response);
        }
    }
    #pragma warning restore CS1591
}