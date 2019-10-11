using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.configuration;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.exceptions;
using SilaAPI.silamoney.client.security;
using SilaAPI.silamoney.client.util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SilaAPI.silamoney.client.api
{
    /// <summary>
    /// Class used to expose the api calls to the developer.
    /// </summary>
    public partial class UserApi
    {
        /// <summary>
        /// UserApi constructor. SilaAPI.silamoney.client.domain.Environments class values can be used for this.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="privateKey"></param>
        /// <param name="appHandle"></param>
        public UserApi(string environment, string privateKey, string appHandle)
        {
            this.Configuration = new Configuration { BasePath = environment, PrivateKey = privateKey, AppHandle = appHandle };
        }

        /// <summary>
        /// UserApi constructor. This uses sandbox environment by default.
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="appHandle"></param>
        public UserApi(string privateKey, string appHandle)
        {
            this.Configuration = Configuration.Default;
            this.Configuration.PrivateKey = privateKey;
            this.Configuration.AppHandle = appHandle;
        }

        /// <summary>
        /// Gets the base path used in the rest client.
        /// </summary>
        /// <returns></returns>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        internal Configuration Configuration { get; set; }

        /// <summary>
        /// Makes a call to the check_handle endpoint.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> CheckHandle(string handle)
        {
            HeaderMsg body = new HeaderMsg(handle, this.Configuration.AppHandle);
            var path = "/check_handle";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));

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

        /// <summary>
        /// Makes a call to the check_kyc endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> CheckKYC(string userHandle, string userPrivateKey)
        {
            HeaderMsg body = new HeaderMsg(userHandle, this.Configuration.AppHandle);
            var path = "/check_kyc";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.Sign(_body, userPrivateKey));

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

        /// <summary>
        /// Makes a call to the get_accounts endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> GetAccounts(string userHandle, string userPrivateKey)
        {
            GetAccountsMsg body = new GetAccountsMsg(userHandle, this.Configuration.AppHandle);
            var path = "/get_accounts";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.Sign(_body, userPrivateKey));

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

        /// <summary>
        /// Makes a call to the get_transactions endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="searchFilters"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> GetTransactions(string userHandle, string userPrivateKey, SearchFilters searchFilters)
        {
            GetTransactionsMsg body = new GetTransactionsMsg(userHandle, this.Configuration.AppHandle, searchFilters);
            var path = "/get_transactions";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.Sign(_body, userPrivateKey));

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

        /// <summary>
        /// Makes a call to the issue_sila endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> IssueSila(string userHandle, float amount, string userPrivateKey, string accountName = "default")
        {
            IssueMsg body = new IssueMsg(userHandle, amount, this.Configuration.AppHandle, accountName);
            var path = "/issue_sila";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.Sign(_body, userPrivateKey));

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

        /// <summary>
        /// Makes a call to the link_account endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="publicToken"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> LinkAccount(string userHandle, string publicToken, string userPrivateKey, string accountName = "default")
        {
            LinkAccountMsg body = new LinkAccountMsg(userHandle, publicToken, this.Configuration.AppHandle, accountName);
            var path = "/link_account";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.Sign(_body, userPrivateKey));

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

        /// <summary>
        /// Makes a call to the redeem_sila endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> RedeemSila(string userHandle, float amount, string userPrivateKey, string accountName = "default")
        {
            RedeemMsg body = new RedeemMsg(userHandle, amount, accountName, this.Configuration.AppHandle);
            var path = "/redeem_sila";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.Sign(_body, userPrivateKey));

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

        /// <summary>
        /// Makes a call to the register endpoint.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> Register(User user)
        {
            EntityMsg body = new EntityMsg(user, this.Configuration.AppHandle);
            var path = "/register";
            var headerParams = new Dictionary<String, String>();
            String _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));

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

        /// <summary>
        /// Makes a call to the request_kyc endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> RequestKYC(string userHandle, string userPrivateKey)
        {
            HeaderMsg body = new HeaderMsg(userHandle, this.Configuration.AppHandle);
            var path = "/request_kyc";
            var headerParams = new Dictionary<String, String>();
            String _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.Sign(_body, userPrivateKey));

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

        /// <summary>
        /// Makes a call to the host api to get the Sila Balance
        /// </summary>
        /// <param name="host"></param>
        /// <param name="address"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> SilaBalance(string host, string address)
        {
            SilaBalanceRequest body = new SilaBalanceRequest(address);
            var path = "/silaBalance";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            string lastBasePath = this.Configuration.BasePath;
            this.Configuration.BasePath = host;

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            this.Configuration.BasePath = lastBasePath;

            int statusCode = (int)response.StatusCode;

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                response.Content);
        }

        /// <summary>
        /// Makes a call to the transfer_sila endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="destinationHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<Object> TransferSila(string userHandle, float amount, string destinationHandle, string userPrivateKey)
        {
            TransferMsg body = new TransferMsg(userHandle, amount, destinationHandle, this.Configuration.AppHandle);
            var path = "/transfer_sila";
            var headerParams = new Dictionary<String, String>();
            string _body = null;

            String contentType = "application/json";

            _body = SerializationUtil.Serialize(body);

            headerParams.Add("authsignature", Signer.Sign(_body, this.Configuration.PrivateKey));
            headerParams.Add("usersignature", Signer.Sign(_body, userPrivateKey));

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
