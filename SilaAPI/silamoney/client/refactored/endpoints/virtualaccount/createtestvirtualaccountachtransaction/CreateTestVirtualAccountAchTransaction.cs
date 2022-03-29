using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.util;

namespace Sila.API.Client.CreateTestVirtualAccountAchTransaction
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateTestVirtualAccountAchTransaction : AbstractEndpoint
    {
        private static string endpoint = "/create_test_virtual_account_ach_transaction";
        private CreateTestVirtualAccountAchTransaction() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(CreateTestVirtualAccountAchTransactionRequest request)
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

            body.Add("amount", request.Amount);
            body.Add("virtual_account_number", request.VirtualAccountNumber);
            body.Add("tran_code", request.TranCode);         
            body.Add("entity_name", request.EntityName);
            body.Add("ced", request.Ced);
            body.Add("ach_name", request.AchName);
            if (request.EffectiveDate != null) body.Add("effective_date", request.EffectiveDate);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<CreateTestVirtualAccountAchTransactionResponse>(response);
        }
    }
}
