using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.util;

namespace Sila.API.Client.Accounts.UpdateAccount
{
    public class UpdateAccount : AbstractEndpoint
    {
        private static string endpoint = "/update_account";
        private UpdateAccount() { }
        public static UpdateAccountResponse Send(UpdateAccountRequest request)
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
            body.Add("account_name", request.AccountName);
            body.Add("new_account_name", request.NewAccountName);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
            headers = HeaderUtils.SetUserSignature(headers, serializedBody, request.UserPrivateKey);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            Console.WriteLine(response.Content);
            if ((int)response.StatusCode == 200)
                return JsonConvert.DeserializeObject<UpdateAccountResponse>(response.Content);
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