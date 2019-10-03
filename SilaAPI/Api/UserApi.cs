using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using SilaAPI.Client;
using SilaAPI.Model;

namespace SilaAPI.Api
{
    public interface IUserApi : IApiAccessor
    {
        ApiResponse<Object> CheckHandle(HeaderMsg body);
        ApiResponse<Object> CheckKYC(HeaderMsg body);
        ApiResponse<Object> GetAccounts(GetAccountsMsg body);
        ApiResponse<Object> GetTransactions(GetTransactionsMsg body);
        ApiResponse<Object> IssueSila(IssueMsg body);
        ApiResponse<Object> LinkAccount(LinkAccountMsg body);
        ApiResponse<Object> RedeemSila(RedeemMsg body);
        ApiResponse<Object> Register(EntityMsg body);
        ApiResponse<Object> RequestKYC(HeaderMsg body);
        ApiResponse<Object> SilaBalance(Address body);
        ApiResponse<Object> TransferSila(TransferMsg body);
    }

    public partial class UserApi : IUserApi
    {
        private SilaAPI.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        public UserApi(String basePath, string privateKey)
        {
            this.Configuration = new SilaAPI.Client.Configuration { BasePath = basePath, PrivateKey = privateKey };

            ExceptionFactory = SilaAPI.Client.Configuration.DefaultExceptionFactory;
        }

        public UserApi(string privateKey)
        {
            this.Configuration = SilaAPI.Client.Configuration.Default;
            this.Configuration.PrivateKey = privateKey;

            ExceptionFactory = SilaAPI.Client.Configuration.DefaultExceptionFactory;
        }

        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }
        
        public SilaAPI.Client.Configuration Configuration { get; set; }

        public SilaAPI.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }
        
        public ApiResponse<Object> CheckHandle(HeaderMsg body)
        {
            var path = "/check_handle";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body);

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CheckHandle", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }
        
        public ApiResponse<Object> CheckKYC(HeaderMsg body)
        {
            var path = "/check_kyc";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body); 

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CheckKYC", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }
        
        public ApiResponse<Object> GetAccounts(GetAccountsMsg body)
        {
            var path = "/get_accounts";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body);

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetAccounts", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public ApiResponse<Object> GetTransactions(GetTransactionsMsg body)
        {
            var path = "/get_transactions";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body);

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTransactions", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public ApiResponse<Object> IssueSila(IssueMsg body)
        {
            var path = "/issue_sila";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body); 

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("IssueSila", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public ApiResponse<Object> LinkAccount(LinkAccountMsg body)
        {
            var path = "/link_account";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body); 

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("LinkAccount", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public ApiResponse<Object> RedeemSila(RedeemMsg body)
        {
            var path = "/redeem_sila";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body); 

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RedeemSila", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public ApiResponse<Object> Register(EntityMsg body)
        {
            var path = "/register";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body); 

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Register", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public ApiResponse<Object> RequestKYC(HeaderMsg body)
        {
            var path = "/request_kyc";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body);

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RequestKYC", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public ApiResponse<Object> SilaBalance(Address body)
        {
            var path = "/silaBalance";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body); 

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SilaBalance", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public ApiResponse<Object> TransferSila(TransferMsg body)
        {
            var path = "/transfer_sila";
            var headerParams = new Dictionary<String, String>();
            Object _body = null;

            String contentType = "application/json";

            _body = this.Configuration.ApiClient.Serialize(body); 

            IRestResponse response = (IRestResponse)this.Configuration.ApiClient.CallApi(path,
                Method.POST, _body, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("TransferSila", response);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }
    }
}
