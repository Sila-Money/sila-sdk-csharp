using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.util;
using Sila.API.Client;
using SilaAPI.silamoney.client.api;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class RedeemSila : AbstractEndpoint
    {
        private static string endpoint = "/redeem_sila";
        private RedeemSila() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(RedeemSilaRequest request)
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
            body.Add("message", "redeem_msg");
            body.Add("account_name", request.AccountName);
            body.Add("descriptor", request.Descriptor);
            body.Add("business_uuid", request.BusinessUuid);
            body.Add("processing_type", request.ProcessingType);
            body.Add("card_name", request.CardName);
            body.Add("source_id", request.SourceId);
            body.Add("destination_id", request.DestinationId);

            string serializedBody = SerializationUtil.Serialize(body);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);

            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

            return ResponseUtils.PrepareResponse<RedeemSilaResponse>(response);
        }
    }
}