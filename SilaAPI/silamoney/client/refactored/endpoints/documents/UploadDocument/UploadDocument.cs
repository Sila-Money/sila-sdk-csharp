using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.util;

namespace Sila.API.Client.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadDocument : AbstractEndpoint
    {
        private static string endpoint = "/documents";
        private UploadDocument() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(UploadDocumentRequest request)
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new Header
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = AppHandle,
                UserHandle = request.UserHandle,
                Crypto = "ETH",
                Reference = UuidUtils.GetUuid(),
                Version = "0.2"
            });
            body.Add("name", request.Name);
            body.Add("filename", request.Filename);
            body.Add("hash", request.Hash);
            body.Add("mime_type", request.MimeType);
            body.Add("document_type", request.DocumentType);
            body.Add("description", request.Description);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<UploadDocumentResponse>(response);
        }
    }
}