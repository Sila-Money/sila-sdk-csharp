using Newtonsoft.Json;
using RestSharp;
using SilaAPI.silamoney.client.configuration;
using SilaAPI.silamoney.client.domain;
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
    public partial class SilaApi
    {
        /// <summary>
        /// UserApi constructor. SilaAPI.silamoney.client.domain.Environments class values can be used for this.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="privateKey"></param>
        /// <param name="appHandle"></param>
        public SilaApi(string environment, string privateKey, string appHandle)
        {
            Configuration = new Configuration { BasePath = environment, PrivateKey = privateKey, AppHandle = appHandle };
        }

        /// <summary>
        /// UserApi constructor. This uses sandbox environment by default.
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="appHandle"></param>
        public SilaApi(string privateKey, string appHandle)
        {
            Configuration = Configuration.Default;
            Configuration.PrivateKey = privateKey;
            Configuration.AppHandle = appHandle;
        }

        /// <summary>
        /// Gets the base path used in the rest client.
        /// </summary>
        /// <returns></returns>
        public string GetBasePath()
        {
            return Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        internal Configuration Configuration { get; set; }

        /// <summary>
        /// Makes a call to the check_handle endpoint.
        /// </summary>
        /// <param name="handle">The user handle to validate if available</param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> CheckHandle(string handle)
        {
            HeaderMsg body = new HeaderMsg(handle, Configuration.AppHandle);
            var path = "/check_handle";

            return MakeRequest<BaseResponse>(path, body);
        }

        /// <summary>
        /// Makes a call to the check_kyc endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> CheckKYC(string userHandle, string userPrivateKey)
        {
            HeaderMsg body = new HeaderMsg(userHandle, Configuration.AppHandle);
            var path = "/check_kyc";

            return MakeRequest<BaseResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the get_accounts endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetAccounts(string userHandle, string userPrivateKey)
        {
            GetAccountsMsg body = new GetAccountsMsg(userHandle, Configuration.AppHandle);
            var path = "/get_accounts";
            return MakeRequest<List<Account>>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the get_transactions endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="searchFilters"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetTransactions(string userHandle, string userPrivateKey, SearchFilters searchFilters)
        {
            GetTransactionsMsg body = new GetTransactionsMsg(userHandle, Configuration.AppHandle, searchFilters);
            var path = "/get_transactions";

            return MakeRequest<GetTransactionsResult>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the issue_sila endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <param name="descriptor"></param>
        /// <param name="businessUuid"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> IssueSila(string userHandle, float amount, string userPrivateKey, string accountName = "default", string descriptor = null, string businessUuid = null)
        {
            IssueMsg body = new IssueMsg(userHandle, amount, this.Configuration.AppHandle, accountName, descriptor, businessUuid);
            var path = "/issue_sila";

            return MakeRequest<TransactionResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the link_account endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="publicToken"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <param name="accountId"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> LinkAccount(string userHandle, string publicToken, string userPrivateKey,
            string accountName = null, string accountId = null)
        {
            LinkAccountMsg body = new LinkAccountMsg(userHandle, publicToken, Configuration.AppHandle, accountId, accountName);
            var path = "/link_account";

            return MakeRequest<LinkAccountResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the link_account endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountNumber"></param>
        /// <param name="accountType"></param>
        /// <param name="routingNumber"></param>
        /// <param name="accountName"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> LinkAccountDirect(string userHandle, string userPrivateKey,
            string accountNumber, string routingNumber, string accountType = null, string accountName = null)
        {
            LinkAccountMsg body = new LinkAccountMsg(userHandle, Configuration.AppHandle, accountNumber,
                routingNumber, accountType, accountName);
            var path = "/link_account";

            return MakeRequest<LinkAccountResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the redeem_sila endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <param name="descriptor"></param>
        /// <param name="businessUuid"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> RedeemSila(string userHandle, float amount, string userPrivateKey, string accountName = "default",
            string descriptor = null, string businessUuid = null)
        {
            RedeemMsg body = new RedeemMsg(userHandle, amount, Configuration.AppHandle, accountName, descriptor, businessUuid);
            var path = "/redeem_sila";

            return MakeRequest<TransactionResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the register endpoint.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> Register(User user)
        {
            EntityMsg body = new EntityMsg(user, Configuration.AppHandle);
            var path = "/register";

            return MakeRequest<BaseResponse>(path, body);
        }

        /// <summary>
        /// Makes a call to the register endpoint.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> Register(BusinessUser user)
        {
            EntityMsg body = new EntityMsg(user, Configuration.AppHandle);
            var path = "/register";

            return MakeRequest<BaseResponse>(path, body);
        }

        /// <summary>
        /// Makes a call to the request_kyc endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> RequestKYC(string userHandle, string userPrivateKey)
        {
            HeaderMsg body = new HeaderMsg(userHandle, Configuration.AppHandle);
            var path = "/request_kyc";

            return MakeRequest<BaseResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the request_kyc endpoint with KYC Level.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="kycLevel"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> RequestKYC(string userHandle, string userPrivateKey, string kycLevel)
        {
            HeaderMsg body = new HeaderMsg(userHandle, Configuration.AppHandle, kycLevel);
            var path = "/request_kyc";

            return MakeRequest<BaseResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the host api to get the Sila Balance
        /// </summary>
        /// <param name="host"></param>
        /// <param name="address"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        [Obsolete("SilaBalance(address) is deprecated. Please use GetSilaBalance(address)")]
        public ApiResponse<object> SilaBalance(string host, string address)
        {
            SilaBalanceRequest body = new SilaBalanceRequest(address);
            var path = "/silaBalance";
            var headerParams = new Dictionary<string, string>();
            var requestBody = SerializationUtil.Serialize(body);

            string contentType = "application/json";

            string lastBasePath = Configuration.BasePath;
            Configuration.BasePath = host;

            IRestResponse response = (IRestResponse)Configuration.ApiClient.CallApi(path,
                Method.POST, requestBody, headerParams, contentType);

            Configuration.BasePath = lastBasePath;

            int statusCode = (int)response.StatusCode;

            object responseBody;

            if (statusCode == 200) responseBody = JsonConvert.DeserializeObject<SilaBalanceResponse>(response.Content);
            else responseBody = JsonConvert.DeserializeObject<BaseResponse>(response.Content);

            return new ApiResponse<object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                responseBody,
                GetSuccess(statusCode, responseBody));
        }

        /// <summary>
        /// Makes a call to get the Sila Balance
        /// </summary>
        /// <param name="address">The wallet address to obtain the balance from</param>
        /// <returns></returns>
        public ApiResponse<object> GetSilaBalance(string address)
        {
            SilaBalanceRequest body = new SilaBalanceRequest(address);
            var path = "/get_sila_balance";

            return MakeRequest<GetSilaBalanceResponse>(path, body);
        }

        /// <summary>
        /// Makes a call to the transfer_sila endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="destinationHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="destinationAddress"></param>
        /// <param name="destinationWallet"></param>
        /// <param name="descriptor"></param>
        /// <param name="businessUuid"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> TransferSila(string userHandle, float amount, string destinationHandle, string userPrivateKey, string destinationAddress = null, string destinationWallet = null,
            string descriptor = null, string businessUuid = null)
        {
            TransferMsg body = new TransferMsg(userHandle, amount, destinationHandle, Configuration.AppHandle, destinationAddress, destinationWallet, descriptor, businessUuid);
            var path = "/transfer_sila";

            return MakeRequest<TransferResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the plaid_sameday_auth endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>        
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> PlaidSameDayAuth(string userHandle, string userPrivateKey, string accountName)
        {
            PlaidSameDayAuthMsg body = new PlaidSameDayAuthMsg(userHandle, Configuration.AppHandle, accountName);
            var path = "/plaid_sameday_auth";

            return MakeRequest<PlaidSameDayAuthResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public ApiResponse<object> GetAccountBalance(string userHandle, string userPrivateKey, string accountName)
        {
            GetAccountBalanceMsg body = new GetAccountBalanceMsg(userHandle, Configuration.AppHandle, accountName);
            string path = "/get_account_balance";

            return MakeRequest<GetAccountBalanceResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Generates a new ETH wallet
        /// </summary>
        /// <returns></returns>
        public UserWallet GenerateWallet()
        {
            return new UserWallet();
        }

        /// <summary>
        /// Makes a call to the get_wallet endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>      
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetWallet(string userHandle, string userPrivateKey)
        {
            GetWalletMsg body = new GetWalletMsg(userHandle, Configuration.AppHandle);
            var path = "/get_wallet";

            return MakeRequest<SingleWalletResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the register_wallet endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>   
        /// <param name="wallet"></param>
        /// <param name="nickname"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> RegisterWallet(string userHandle, string userPrivateKey, UserWallet wallet, string nickname)
        {
            RegisterWalletMsg body = new RegisterWalletMsg(userHandle, Configuration.AppHandle, wallet, nickname);
            var path = "/register_wallet";

            return MakeRequest<RegisterWalletResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the update_wallet endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>   
        /// <param name="nickname"></param>  
        /// <param name="isDefault"></param>     
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> UpdateWallet(string userHandle, string userPrivateKey, string nickname = null, bool? isDefault = null)
        {
            UpdateWalletMsg body = new UpdateWalletMsg(userHandle, Configuration.AppHandle, nickname, isDefault);
            var path = "/update_wallet";

            return MakeRequest<UpdateWalletResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the delete_wallet endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>     
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> DeleteWallet(string userHandle, string userPrivateKey)
        {
            DeleteWalletMsg body = new DeleteWalletMsg(userHandle, Configuration.AppHandle);
            var path = "/delete_wallet";

            return MakeRequest<DeleteWalletResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to the get_wallets endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="searchFilters"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetWallets(string userHandle, string userPrivateKey, WalletSearchFilters searchFilters = null)
        {
            GetWalletsMsg body = new GetWalletsMsg(userHandle, Configuration.AppHandle, searchFilters);
            var path = "/get_wallets";

            return MakeRequest<GetWalletsResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to /get_business_types.
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetBusinessTypes()
        {
            var path = "/get_business_types";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("auth_handle", Configuration.AppHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);

            return MakeRequest<BusinessTypesResponse>(path, body);
        }

        /// <summary>
        /// Makes a call to /get_business_roles.
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetBusinessRoles()
        {
            var path = "/get_business_roles";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("auth_handle", Configuration.AppHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);

            return MakeRequest<BusinessRolesResponse>(path, body);
        }

        /// <summary>
        /// Makes a call to /get_naics_categories.
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetNaicsCategories()
        {
            var path = "/get_naics_categories";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("auth_handle", Configuration.AppHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);

            return MakeRequest<NaicsCategoriesResponse>(path, body);
        }

        /// <summary>
        /// Makes a call to /link_business_member.
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="businessHandle"></param>
        /// <param name="businessPrivateKey"></param>
        /// <param name="businessRole"></param>
        /// <param name="details"></param>
        /// <param name="memberHandle"></param>
        /// <param name="ownershipStake"></param>
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> LinkBusinessMember(string userHandle, string userPrivateKey, string businessHandle, string businessPrivateKey, BusinessRole businessRole, string details = null, string memberHandle = null, float ownershipStake = -1)
        {
            var path = "/link_business_member";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("auth_handle", Configuration.AppHandle);
            header.Add("user_handle", userHandle);
            header.Add("business_handle", businessHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);
            body.Add("role", businessRole.Label);
            body.Add("role_uuid", businessRole.Uuid);
            if (details != null) body.Add("details", details);
            if (memberHandle != null) body.Add("member_handle", memberHandle);
            if (ownershipStake != -1) body.Add("ownership_stake", ownershipStake);

            return MakeRequest<LinkOperationResponse>(path, body, userPrivateKey, businessPrivateKey);
        }

        /// <summary>
        /// Makes a call to /link_business_member.
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="businessHandle"></param>
        /// <param name="businessPrivateKey"></param>
        /// <param name="businessRole"></param>
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> UnlinkBusinessMember(string userHandle, string userPrivateKey, string businessHandle, string businessPrivateKey, BusinessRole businessRole)
        {
            var path = "/unlink_business_member";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("auth_handle", Configuration.AppHandle);
            header.Add("user_handle", userHandle);
            header.Add("business_handle", businessHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);
            body.Add("role", businessRole.Label);
            body.Add("role_uuid", businessRole.Uuid);

            return MakeRequest<LinkOperationResponse>(path, body, userPrivateKey, businessPrivateKey);
        }

        /// <summary>
        /// Makes a call to /link_business_member.
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="businessHandle"></param>
        /// <param name="businessPrivateKey"></param>
        /// <param name="memberHandle"></param>
        /// <param name="certificationToken"></param>
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> UnlinkBusinessMember(string userHandle, string userPrivateKey, string businessHandle, string businessPrivateKey, string memberHandle, string certificationToken)
        {
            var path = "/certify_beneficial_owner";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("auth_handle", Configuration.AppHandle);
            header.Add("user_handle", userHandle);
            header.Add("business_handle", businessHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);
            body.Add("member_handle", memberHandle);
            body.Add("certification_token", certificationToken);

            return MakeRequest<BaseResponse>(path, body, userPrivateKey, businessPrivateKey);
        }

        /// <summary>
        /// Makes a call to /link_business_member.
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetEntity(string userHandle, string userPrivateKey)
        {
            var path = "/get_entity";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("auth_handle", Configuration.AppHandle);
            header.Add("user_handle", userHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);

            return MakeRequest<GetEntityResponse>(path, body, userPrivateKey);
        }

        private ApiResponse<object> MakeRequest<T>(string path, object body, string userPrivateKey = null, string businessPrivateKey = null)
        {
            var headerParams = new Dictionary<string, string>();
            string requestBody = SerializationUtil.Serialize(body);
            string contentType = "application/json";

            headerParams.Add("authsignature", Signer.Sign(requestBody, Configuration.PrivateKey));
            if (userPrivateKey != null) headerParams.Add("usersignature", Signer.Sign(requestBody, userPrivateKey));
            if (businessPrivateKey != null) headerParams.Add("businesssignature", Signer.Sign(requestBody, businessPrivateKey));

            IRestResponse response = (IRestResponse)Configuration.ApiClient.CallApi(path, Method.POST, requestBody, headerParams, contentType);

            int statusCode = (int)response.StatusCode;

            object responseBody;

            Console.WriteLine(response.Content);

            switch (statusCode)
            {
                case 200:
                    responseBody = JsonConvert.DeserializeObject<T>(response.Content);
                    break;
                case 400:
                    responseBody = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);
                    break;
                case 500:
                    responseBody = JsonConvert.DeserializeObject<BaseResponse>(response.Content);
                    break;
                default:
                    responseBody = JsonConvert.DeserializeObject<BaseResponse>(response.Content);
                    break;
            }

            return new ApiResponse<object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                responseBody,
                GetSuccess(statusCode, responseBody));
        }

        private bool GetSuccess(int statusCode, object body)
        {
            if (statusCode != 200) return false;

            if (body.GetType() == typeof(BaseResponse) && ((BaseResponse)body).Status != "SUCCESS")
                return false;

            return true;
        }
    }
}
