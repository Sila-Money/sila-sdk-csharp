using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.configuration;
using System;
using System.Collections.Generic;

namespace Sila.API
{
    /// <summary>
    /// Class used to prepare requests and make calls to the api server.
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        /// ApiClient constructor.
        /// </summary>
        /// <param name="basePath"></param>
        public ApiClient(string basePath)
        {
            if (string.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            RestClient = new RestClient(basePath);
            Configuration = Configuration.Default;
        }

        public bool Debug { get; set; }

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
            string path, Method method, object postBody, Dictionary<string, string> headerParams,
            string contentType)
        {
            var request = new RestRequest(path, method);

            foreach (var param in headerParams)
                request.AddHeader(param.Key, param.Value);
            if (Configuration.Debug)
                Console.WriteLine(JsonConvert.SerializeObject(postBody));

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
        public object CallApi(
            string path, Method method, object postBody, Dictionary<string, string> headerParams,
            string contentType)
        {
            var request = PrepareRequest(
                path, method, postBody, headerParams, contentType);

            RestClient.Timeout = Configuration.Timeout;
            RestClient.UserAgent = Configuration.UserAgent;

            var response = RestClient.Execute(request);

            return response;
        }

        public object CallApi(string path, Method method, object postBody, Dictionary<string, string> headerParams, string filePath, string contentType)
        {
            var request = new RestRequest(path, method, DataFormat.None);
            foreach (var param in headerParams)
                request.AddHeader(param.Key, param.Value);

            request.AddFile("file", filePath, contentType);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("data", postBody, ParameterType.GetOrPost);

            RestClient.Timeout = Configuration.Timeout;
            RestClient.UserAgent = Configuration.UserAgent;

            return RestClient.Execute(request);
        }
    }
}
