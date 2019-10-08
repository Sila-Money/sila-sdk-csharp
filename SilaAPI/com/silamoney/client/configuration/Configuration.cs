using SilaAPI.com.silamoney.client.api;
using System;
using System.Collections.Generic;

namespace SilaAPI.com.silamoney.client.configuration
{
    public class Configuration
    {
        #region Static Members

        private static readonly object GlobalConfigSync = new { };
        private static Configuration _globalConfiguration;

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
            _globalConfiguration = new Configuration();
        }

        public Configuration()
        {
            UserAgent = "SilaSDK/1.0.0/csharp";
            BasePath = "https://sandbox.silamoney.com/0.2";
            AppHandler = "handle.silamoney.eth";

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

        private String _appHandler = null;

        public virtual string AppHandler
        {
            get { return _appHandler; }
            set { _appHandler = value; }
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
