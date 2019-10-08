using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using SilaAPI.silamoney.client.exceptions;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.util;
using SilaAPI.silamoney.client.configuration;
using SilaAPI.silamoney.client.security;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.api
{
    public partial class UserApi
    {
        public UserApi(String basePath, string privateKey, string appHandle)
        {
            this.Configuration = new Configuration { BasePath = basePath, PrivateKey = privateKey, appHandle = appHandle };
        }

        public UserApi(string privateKey, string appHandle)
        {
            this.Configuration = Configuration.Default;
            this.Configuration.PrivateKey = privateKey;
            this.Configuration.appHandle = appHandle;
        }

        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        public Configuration Configuration { get; set; }

        public ApiResponse<Object> CheckHandle(string handle)
        {
            HeaderMsg body = new HeaderMsg(handle, this.Configuration.appHandle);
            var path = "/check_handle";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Handle sent in header.user_handle is a reserved handle "
                            + "according to our JSON schema. (Or: request body otherwise does not conform to JSON schema.)");
                case 401:
                    throw new InvalidSignatureException("Auth signature is absent or derived address does not "
                        + "belong to auth_handle.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<BaseResponse>(response.Content));
        }

        public ApiResponse<Object> CheckKYC(string userHandle, string userPrivateKey)
        {
            HeaderMsg body = new HeaderMsg(userHandle,this.Configuration.appHandle);
            var path = "/check_kyc";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.sign(_body, userPrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format.");
                case 401:
                    throw new InvalidSignatureException("authsignature or usersignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<BaseResponse>(response.Content));
        }

        public ApiResponse<Object> GetAccounts(string userHandle, string userPrivateKey)
        {
            GetAccountsMsg body = new GetAccountsMsg(userHandle, this.Configuration.appHandle);
            var path = "/get_accounts";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.sign(_body, userPrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format.");
                case 401:
                    throw new InvalidSignatureException("authsignature or usersignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<GetAccountsResponse>(response.Content));
        }

        public ApiResponse<Object> GetTransactions(string userHandle, string userPrivateKey, SearchFilters searchFilters)
        {
            GetTransactionsMsg body = new GetTransactionsMsg(userHandle, this.Configuration.appHandle, searchFilters);
            var path = "/get_transactions";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.sign(_body, userPrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format.");
                case 403:
                    throw new InvalidSignatureException("authsignature or usersignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<GetTransactionsResponse>(response.Content));
        }

        public ApiResponse<Object> IssueSila(string userHandle, float amount, string userPrivateKey, string accountName = "default")
        {
            IssueMsg body = new IssueMsg(userHandle, amount, this.Configuration.appHandle, accountName);
            var path = "/issue_sila";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.sign(_body, userPrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format.");
                case 401:
                    throw new InvalidSignatureException("authsignature or usersignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<BaseResponse>(response.Content));
        }

        public ApiResponse<Object> LinkAccount(string userHandle, string publicToken, string userPrivateKey, string accountName = "default")
        {
            LinkAccountMsg body = new LinkAccountMsg(userHandle, publicToken, this.Configuration.appHandle, accountName);
            var path = "/link_account";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.sign(_body, userPrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format.");
                case 401:
                    throw new InvalidSignatureException("authsignature or usersignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<BaseResponse>(response.Content));
        }

        public ApiResponse<Object> RedeemSila(string userHandle, float amount, string userPrivateKey, string accountName = "default")
        {
            RedeemMsg body = new RedeemMsg(userHandle, amount, accountName, this.Configuration.appHandle);
            var path = "/redeem_sila";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.sign(_body, userPrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format.");
                case 401:
                    throw new InvalidSignatureException("authsignature or usersignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<BaseResponse>(response.Content));
        }

        public ApiResponse<Object> Register(User user)
        {
            EntityMsg body = new EntityMsg(user, this.Configuration.appHandle);
            var path = "/register";
            var headerParams = new Dictionary<String, String>();
            String _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format, handle already in use, or blockchain address already in use.");
                case 401:
                    throw new InvalidSignatureException("authsignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<BaseResponse>(response.Content));
        }

        public ApiResponse<Object> RequestKYC(string userHandle, string userPrivateKey)
        {
            HeaderMsg body = new HeaderMsg(userHandle, this.Configuration.appHandle);
            var path = "/request_kyc";
            var headerParams = new Dictionary<String, String>();
            String _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.sign(_body, userPrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format.");
                case 401:
                    throw new InvalidSignatureException("authsignature or usersignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<BaseResponse>(response.Content));
        }

        public ApiResponse<Object> SilaBalance(string address)
        {
            SilaBalanceRequest body = new SilaBalanceRequest(address);
            var path = "/silaBalance";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                response.Content);
        }

        public ApiResponse<Object> TransferSila(string userHandle, float amount, string destinationHandle, string userPrivateKey)
        {
            TransferMsg body = new TransferMsg(userHandle, amount, destinationHandle, this.Configuration.appHandle);
            var path = "/transfer_sila";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.sign(_body, userPrivateKey));

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    throw new BadRequestException("Invalid request body format.");
                case 401:
                    throw new InvalidSignatureException("authsignature or usersignature header was absent or incorrect.");
                case 500:
                    throw new ServerSideException();
                default:
                    break;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                JsonConvert.DeserializeObject<BaseResponse>(response.Content));
        }
    }
}
