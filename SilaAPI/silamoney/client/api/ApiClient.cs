using System;
using System.Collections.Generic;
using RestSharp;
using SilaAPI.silamoney.client.configuration;

namespace SilaAPI.silamoney.client.api
{
    /// <summary>
    /// Class used to prepare requests and make calls to the api server.
    /// </summary>
    internal partial class ApiClient
    {
        /// <summary>
        /// ApiClient constructor.
        /// </summary>
        /// <param name="basePath"></param>
        public ApiClient(String basePath = "https://sandbox.silamoney.com/0.2")
        {
            if (String.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            RestClient = new RestClient(basePath);
            Configuration = Configuration.Default;
        }

        /// <summary>
        /// ApiClient configuration.
        /// </summary>
        internal Configuration Configuration { get; set; }

        /// <summary>
        /// Rest Client used in the ApiClient
        /// </summary>
        public RestClient RestClient { get; set; }

        /// <summary>
        /// Creates a rest request adding the headers and parameters.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="postBody"></param>
        /// <param name="headerParams"></param>
        /// <param name="contentType"></param>
        /// <returns>RestRequest with headers and parameters.</returns>
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

        /// <summary>
        /// Executes a Rest call useing the prepared request.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="postBody"></param>
        /// <param name="headerParams"></param>
        /// <param name="contentType"></param>
        /// <returns>The response from the server.</returns>
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
