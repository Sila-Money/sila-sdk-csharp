﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Domain;
using Sila.API.Client.Exceptions;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.security;
using SilaAPI.silamoney.client.util;
namespace Sila.API.Client.Wallets
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterWallet : AbstractEndpoint
    {
        private static string endpoint = "/register_wallet";
        private RegisterWallet() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ApiResponse<object> Send(RegisterWalletRequest request)
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
            if (!string.IsNullOrWhiteSpace(request.Wallet.PrivateKey))
                body.Add("wallet_verification_signature", Signer.Sign(request.Wallet.Address, request.Wallet.PrivateKey));
            body.Add("wallet", new Wallet(request.Wallet.Address, CryptoEnum.Crypto.ETH, request.NickName, request.IsDefault));
            string serializedBody = SerializationUtil.Serialize(body);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
            IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");
            return ResponseUtils.PrepareResponse<RegisterWalletResponse>(response);
        }
    }

}
