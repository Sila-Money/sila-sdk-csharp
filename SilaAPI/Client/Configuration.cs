using System;
using System.Collections.Generic;

namespace SilaAPI.Client
{
    public class Configuration : IReadableConfiguration
    {
        #region Static Members

        private static readonly object GlobalConfigSync = new { };
        private static Configuration _globalConfiguration;

        public static readonly ExceptionFactory DefaultExceptionFactory = (methodName, response) =>
        {
            var status = (int)response.StatusCode;
            if (status >= 400)
            {
                return new ApiException(status,
                    string.Format("Error calling {0}: {1}", methodName, response.Content),
                    response.Content);
            }
            if (status == 0)
            {
                return new ApiException(status,
                    string.Format("Error calling {0}: {1}", methodName, response.ErrorMessage), response.ErrorMessage);
            }
            return null;
        };

        public static Configuration Default
        {
            get { return _globalConfiguration; }
            set
            {
                lock (GlobalConfigSync)
                {
                    _globalConfiguration = value;
                }
            }
        }

        #endregion Static Members

        #region Constructors

        static Configuration()
        {
            _globalConfiguration = new GlobalConfiguration();
        }

        public Configuration()
        {
            UserAgent = "SilaSDK/1.0.0/csharp";
            BasePath = "https://sandbox.silamoney.com/0.2";

            Timeout = 100000;
        }
        
        #endregion Constructors


        #region Properties

        private ApiClient _apiClient = null;
        
        public virtual ApiClient ApiClient
        {
            get
            {
                if (_apiClient == null) _apiClient = CreateApiClient();
                return _apiClient;
            }
        }

        private String _basePath = null;
        
        public virtual string BasePath
        {
            get { return _basePath; }
            set
            {
                _basePath = value;
                // pass-through to ApiClient if it's set.
                if (_apiClient != null)
                {
                    _apiClient.RestClient.BaseUrl = new Uri(_basePath);
                }
            }
        }

        private String _privateKey = null;

        public virtual string PrivateKey
        {
            get { return _privateKey; }
            set { _privateKey = value; }
        }

        public virtual int Timeout
        {

            get { return ApiClient.RestClient.Timeout; }
            set { ApiClient.RestClient.Timeout = value; }
        }

        public virtual string UserAgent { get; set; }

        #endregion Properties

        #region Methods
        
        public ApiClient CreateApiClient()
        {
            return new ApiClient(BasePath) { Configuration = this };
        }
        #endregion Methods
    }
}
