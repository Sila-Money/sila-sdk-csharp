using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.util;

namespace Sila.API.Client.Accounts
{
    public class GetInstitutions : AbstractEndpoint
    {
        private static string endpoint = "/get_institutions";
        private GetInstitutions() { }
        public static ApiResponse<object> Send(GetInstitutionsRequest request = null)
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

            if (request != null)
            {
                Dictionary<string, object> searchFilters = new Dictionary<string, object>();
                searchFilters.Add("institution_name", request.InstitutionName);
                searchFilters.Add("routing_number", request.RoutingNumber);
                searchFilters.Add("page", request.Page);
                searchFilters.Add("per_page", request.PerPage);
                body.Add("search_filters", searchFilters);
            }

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<GetInstitutionsResponse>(response);
        }
    }
}