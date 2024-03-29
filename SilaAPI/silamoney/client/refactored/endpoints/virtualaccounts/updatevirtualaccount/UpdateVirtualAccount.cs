﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;

namespace Sila.API.Client.VirtualAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVirtualAccount : AbstractEndpoint
    {
        private static string endpoint = "/update_virtual_account";
        private UpdateVirtualAccount() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(UpdateVirtualAccountRequest request)
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

            body.Add("virtual_account_id", request.VirtualAccountId);
            body.Add("virtual_account_name", request.VirtualAccountName);
            body.Add("active", request.Active);
            if (request.AchCreditEnabled != null) body.Add("ach_credit_enabled", request.AchCreditEnabled);
            if (request.AchDebitEnabled != null) body.Add("ach_debit_enabled", request.AchDebitEnabled);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<UpdateVirtualAccountResponse>(response);
        }
    }
}
