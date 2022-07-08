using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using Sila.API.Client.security;

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
            Dictionary<string, Dictionary<string, string>> fileDictionary = new Dictionary<string, Dictionary<string, string>>();
            int i = 1;
            string myfile = "file_";
            foreach (var lst in request.UploadDocument)
            {
                FileStream file = new FileStream(lst.FilePath, FileMode.Open);
                string hash = Signer.HashFile(file);
                file.Close();
                Dictionary<string, string> innerBody = new Dictionary<string, string>();
                innerBody.Add("filename", lst.FileName);
                innerBody.Add("hash", hash);
                innerBody.Add("mime_type", lst.MimeType);
                innerBody.Add("document_type", lst.DocumentType);
                innerBody.Add("name", lst.Name);
                innerBody.Add("description", lst.Description);
                fileDictionary.Add(myfile + i, innerBody);
                i++;
            }
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
            body.Add("file_metadata", fileDictionary);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, request.UploadDocument);

            return ResponseUtils.PrepareResponse<UploadDocumentResponse>(response);
        }
    }
}