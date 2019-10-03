using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace SilaAPI.Client
{
    public partial class ApiClient
    {
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };
        
        public ApiClient(String basePath = "https://sandbox.silamoney.com/0.2")
        {
            if (String.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            RestClient = new RestClient(basePath);
            Configuration = Client.Configuration.Default;
        }
        
        public IReadableConfiguration Configuration { get; set; }

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
        
        public String Serialize(object obj)
        {
            return obj != null ? JsonConvert.SerializeObject(obj) : null;
        }
    }
}
