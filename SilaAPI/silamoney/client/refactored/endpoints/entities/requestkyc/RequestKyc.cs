using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.refactored.domain;
using SilaAPI.silamoney.client.util;

public class RequestKyc : AbstractEndpoint
{
    private static string endpoint = "/request_kyc";
    private RequestKyc() { }
    public static RequestKycResponse Send(RequestKycRequest request)
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
        body.Add("message", "header_msg");
        body.Add("kyc_level", request.KycLevel);

        string serializedBody = SerializationUtil.Serialize(body);

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers = HeaderUtils.SetAuthSignature(headers, serializedBody);
        headers = HeaderUtils.SetUserSignature(headers, serializedBody, request.UserPrivateKey);

        IRestResponse response = (IRestResponse)ApiClient.CallApi(endpoint, RestSharp.Method.POST, serializedBody, headers, "application/json");

        Console.WriteLine(response.Content);
        if ((int)response.StatusCode == 200)
            return JsonConvert.DeserializeObject<RequestKycResponse>(response.Content);
        if ((int)response.StatusCode == 400)
            throw new BadRequestException(response.Content);
        if ((int)response.StatusCode == 401)
            throw new InvalidSignatureException(response.Content);
        if ((int)response.StatusCode == 403)
            throw new ForbiddenException(response.Content);

        throw new Exception(response.Content);
    }
}