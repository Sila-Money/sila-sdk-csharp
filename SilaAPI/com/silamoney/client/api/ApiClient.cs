using System;
using System.Collections.Generic;
using RestSharp;
using SilaAPI.com.silamoney.client.configuration;

namespace SilaAPI.com.silamoney.client.api
{
    public partial class ApiClient
    {        
        public ApiClient(String basePath = "https://sandbox.silamoney.com/0.2")
        {
            if (String.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            RestClient = new RestClient(basePath);
            Configuration = Configuration.Default;
        }
        
        public Configuration Configuration { get; set; }

        public RestClient RestClient { get; set; }

        private RestRequest PrepareRequest(
            String path, RestSharp.Method method, Object postBody, Dictionary<String, String> headerParams, 
            String contentType)
        {
            var request = new RestRequest(path, method);
            
            foreach (var param in headerParams)
                request.AddHeader(param.Key, param.Value);

            request.AddParameter(contentType, postBody, ParameterType.RequestBody);

            return request;
        }

        public Object CallApi(
            String path, RestSharp.Method method, Object postBody, Dictionary<String, String> headerParams,
            String contentType)
        {
            var request = PrepareRequest(
                path, method, postBody, headerParams, contentType);

            RestClient.Timeout = Configuration.Timeout;
            RestClient.UserAgent = Configuration.UserAgent;

            var response = RestClient.Execute(request);

            return (Object)response;
        }
    }
}
