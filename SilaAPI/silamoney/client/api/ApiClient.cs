﻿using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.configuration;
using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SilaAPITestProject")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace SilaAPI.silamoney.client.api
{
    /// <summary>
    /// Class used to prepare requests and make calls to the api server.
    /// </summary>
    public partial class ApiClient
    {
        /// <summary>
        /// ApiClient constructor.
        /// </summary>
        /// <param name="basePath"></param>
        public ApiClient(string basePath = Environments.sandbox)
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
        private RestRequest PrepareRequest(string path, Method method, object postBody, Dictionary<string, string> headerParams, string contentType)
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
        /// Creates a rest request adding the headers and parameters.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="headerParams"></param>
        /// <param name="postBody"></param>
        /// <param name="contentType"></param>
        /// <returns>RestRequest with headers and parameters.</returns>
        private RestRequest PrepareGetRequest(string path, Method method, object postBody, Dictionary<string, string> headerParams, string contentType)
        {
            var request = new RestRequest(path, Method.GET, DataFormat.Json);

            foreach (var param in headerParams)
                request.AddHeader(param.Key, param.Value);
            if (Configuration.Debug)
                Console.WriteLine(JsonConvert.SerializeObject(postBody));

            //request.AddJsonBody(postBody);
            
            //request.AddStringBody(postBody.ToString(), DataFormat.Json);
            //request.AddStringBody(body, DataFormat.Json);
            //request.AddParameter(contentType, postBody, ParameterType.RequestBody);
            request.AddParameter("application/json", postBody.ToString(), ParameterType.RequestBody);
            //request.AddParameter(new JsonParameter("", postBody));
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
        public virtual object CallApi(string path, Method method, object postBody, Dictionary<string, string> headerParams, string contentType)
        {
            var request = PrepareRequest(
                path, method, postBody, headerParams, contentType);

            RestClient.Timeout = Configuration.Timeout;
            RestClient.UserAgent = Configuration.UserAgent;

            var response = RestClient.Execute(request);

            return response;
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
        public object CallGetApi(string path, Method method, object postBody, Dictionary<string, string> headerParams, string contentType)
        {
            var request = PrepareGetRequest(
                path, method, postBody, headerParams, contentType);

            RestClient.Timeout = Configuration.Timeout;
            RestClient.UserAgent = Configuration.UserAgent;

            var response = RestClient.Execute(request);

            return response;
        }

        public virtual object CallApi(string path, Method method, object postBody, Dictionary<string, string> headerParams, string filePath, string contentType)
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

        public virtual object CallApi(string path, Method method, object postBody, Dictionary<string, string> headerParams, List<UploadDocument> uploadDocument)
        {
            var request = new RestRequest(path, method, DataFormat.None);
            foreach (var param in headerParams)
                request.AddHeader(param.Key, param.Value);

            int i = 1;
            string myfile = "file_";
            foreach (var lst in uploadDocument)
            {
                request.AddFile(myfile + i, lst.FilePath, lst.MimeType);
                i++;
            }

            request.AlwaysMultipartFormData = true;
            request.AddParameter("data", postBody, ParameterType.GetOrPost);

            RestClient.Timeout = Configuration.Timeout;
            RestClient.UserAgent = Configuration.UserAgent;

            return RestClient.Execute(request);
        }
    }
}
