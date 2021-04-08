using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;

namespace SilaAPI.silamoney.client.configuration
{
    /// <summary>
    /// Configuration object used to set the basepath, appHandle, privateKey, apiClient, timeout, and userAgent.
    /// </summary>
    internal class Configuration
    {
        #region Static Members

        private static readonly object GlobalConfigSync = new { };
        private static Configuration _globalConfiguration = new Configuration();

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


        public Configuration()
        {
            UserAgent = "SilaSDK-.net/0.2.22";
            BasePath = Environments.SANDBOX;
            Debug = false;
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

        private string _basePath = null;

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

        public virtual bool Debug { get; set; }

        public virtual string PrivateKey { get; set; }

        public virtual string AppHandle { get; set; }

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
