using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System.Collections.Generic;
using System.Linq;

namespace Sila.API.Client.Utils
{
    public class ResponseUtils
    {
        private ResponseUtils() { }

        public static ApiResponse<object> PrepareResponseGetAccounts(IRestResponse rawResponse)
        {
            int statusCode = (int)rawResponse.StatusCode;

            object responseBody;

            switch (statusCode)
            {
                case 200:
                    List<Sila.API.Client.Domain.Account> accounts = JsonConvert.DeserializeObject<List<Sila.API.Client.Domain.Account>>(rawResponse.Content);
                    return new ApiResponse<object>(statusCode,
                rawResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                new Sila.API.Client.Accounts.GetAccounts.GetAccountsResponse(accounts),
                GetSuccess(statusCode, accounts));
                case 400:
                    responseBody = JsonConvert.DeserializeObject<BadRequestResponse>(rawResponse.Content);
                    break;
                case 500:
                    responseBody = JsonConvert.DeserializeObject<BaseResponse>(rawResponse.Content);
                    break;
                default:
                    responseBody = JsonConvert.DeserializeObject<BaseResponse>(rawResponse.Content);
                    break;
            }

            return new ApiResponse<object>(statusCode,
                rawResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                responseBody,
                GetSuccess(statusCode, responseBody));
        }

        public static ApiResponse<object> PrepareResponse<T>(IRestResponse rawResponse)
        {
            int statusCode = (int)rawResponse.StatusCode;

            object responseBody;

            switch (statusCode)
            {
                case 200:
                    responseBody = JsonConvert.DeserializeObject<T>(rawResponse.Content);
                    break;
                case 400:
                    responseBody = JsonConvert.DeserializeObject<BadRequestResponse>(rawResponse.Content);
                    break;
                case 500:
                    responseBody = JsonConvert.DeserializeObject<BaseResponse>(rawResponse.Content);
                    break;
                default:
                    responseBody = JsonConvert.DeserializeObject<BaseResponse>(rawResponse.Content);
                    break;
            }

            return new ApiResponse<object>(statusCode,
                rawResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                responseBody,
                GetSuccess(statusCode, responseBody));
        }

        private static bool GetSuccess(int statusCode, object body)
        {
            if (statusCode != 200) return false;

            if (body.GetType() == typeof(BaseResponse) && (((BaseResponse)body).Status != "SUCCESS" && ((BaseResponse)body).Status != null))
                return false;

            return true;
        }
    }
}