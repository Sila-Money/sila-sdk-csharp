using Newtonsoft.Json;
using RestSharp;
using Sila.API.Client.Utils;
using SilaAPI.silamoney.client.configuration;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.security;
using SilaAPI.silamoney.client.util;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <param name="debug"></param>
        public SilaApi(string environment, string privateKey, string appHandle, bool debug = false)
        {
            Configuration = new Configuration { BasePath = environment, PrivateKey = privateKey, AppHandle = appHandle, Debug = debug };
        }

        /// <summary>
        /// UserApi constructor. This uses sandbox environment by default.
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="appHandle"></param>
        /// <param name="debug"></param>
        public SilaApi(string privateKey, string appHandle, bool debug = false)
        {
            Configuration = Configuration.Default;
            Configuration.PrivateKey = privateKey;
            Configuration.AppHandle = appHandle;
            Configuration.Debug = debug;
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

            return MakeRequest<CheckKYCResponse>(path, body, userPrivateKey);
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
            ApiResponse<object> response = MakeRequest<List<Account>>(path, body, userPrivateKey);
            if (response.Data is List<Account> list)
            {
                response.Data = new GetAccountsResponse { Accounts = list };
            }
            return response;
        }

        /// <summary>
        /// Makes a call to the get_transactions endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="searchFilters"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        [Obsolete("This method is obsolet, you don't need to pass the userPrivateKey parameter anymore.")]
        public ApiResponse<object> GetTransactions(string userHandle, string userPrivateKey, SearchFilters searchFilters)
        {
            return GetTransactions(userHandle, searchFilters);
        }

        /// <summary>
        /// Makes a call to the get_transactions endpoint.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="searchFilters"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetTransactions(string userHandle, SearchFilters searchFilters)
        {
            GetTransactionsMsg body = new GetTransactionsMsg(userHandle, Configuration.AppHandle, searchFilters);
            var path = "/get_transactions";

            return MakeRequest<GetTransactionsResult>(path, body);
        }

        /// <summary>
        /// Initiates and ACH Debit transaction on a specified bank account and issues SILAUSD tokens to the address belonging to the requested handle.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount">Min Length 1, Max digits 35</param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName">Required. Max Length 40</param>
        /// <param name="descriptor">Optional. Max Length 100</param>
        /// <param name="businessUuid">Optional. UUID of a business with an approved ACH name.</param>
        /// <param name="processingType">Optional.</param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> IssueSila(string userHandle, int amount, string userPrivateKey, string accountName = "default", string descriptor = null, string businessUuid = null, ProcessingType? processingType = null)
        {
            BankTransactionMessage body = new BankTransactionMessage(userHandle, amount, this.Configuration.AppHandle, accountName, descriptor, businessUuid, processingType, BaseMessage.Message.IssueMsg);
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
        /// <param name="plaidTokenType"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        /// 
        public ApiResponse<object> LinkAccount(string userHandle, string publicToken, string userPrivateKey,
            string accountName = null, string accountId = null, string plaidTokenType = null)
        {
            LinkAccountMsg body = new LinkAccountMsg(userHandle, publicToken, Configuration.AppHandle, accountId, accountName);
            body.PlaidTokenType = plaidTokenType;
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
        /// <param name="processingType"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> RedeemSila(string userHandle, int amount, string userPrivateKey, string accountName = "default",
            string descriptor = null, string businessUuid = null, ProcessingType? processingType = null)
        {
            BankTransactionMessage body = new BankTransactionMessage(userHandle, amount, Configuration.AppHandle, accountName, descriptor, businessUuid, processingType, BaseMessage.Message.RedeemMsg);
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

            return MakeRequest<BusinessUserResponse>(path, body);
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

            return MakeRequest<RequestKYCResponse>(path, body, userPrivateKey);
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

            return MakeRequest<RequestKYCResponse>(path, body, userPrivateKey);
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
        public ApiResponse<object> TransferSila(string userHandle, int amount, string destinationHandle, string userPrivateKey, string destinationAddress = null, string destinationWallet = null,
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
        /// <param name="isDefault">optional</param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> RegisterWallet(string userHandle, string userPrivateKey, UserWallet wallet, string nickname, bool? isDefault = null)
        {
            RegisterWalletMsg body = new RegisterWalletMsg(userHandle, Configuration.AppHandle, wallet, nickname, isDefault);
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
            header.Add("app_handle", Configuration.AppHandle);

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
            header.Add("app_handle", Configuration.AppHandle);

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
            header.Add("app_handle", Configuration.AppHandle);

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
            header.Add("app_handle", Configuration.AppHandle);
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
        /// Makes a call to /unlink_business_member.
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
            header.Add("app_handle", Configuration.AppHandle);
            header.Add("user_handle", userHandle);
            header.Add("business_handle", businessHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);
            body.Add("role", businessRole.Label);
            body.Add("role_uuid", businessRole.Uuid);

            return MakeRequest<LinkOperationResponse>(path, body, userPrivateKey, businessPrivateKey);
        }

        /// <summary>
        /// Makes a call to /get_entity.
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="prettyDates"></param>
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetEntity(string userHandle, string userPrivateKey, bool? prettyDates = null)
        {
            var path = $"/get_entity{UrlParamsUtilities.AddQueryParameter("", "pretty_dates", prettyDates.ToString())}";
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("app_handle", Configuration.AppHandle);
            header.Add("user_handle", userHandle);

            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", header);

            return MakeRequest<GetEntityResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Makes a call to /get_entities.
        /// </summary>
        /// <param name="entityTypeFilter"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> GetEntities(string entityTypeFilter = null, int? page = null, int? perPage = null)
        {
            string path = $"/get_entities{GetRequestParams(page, perPage)}";
            Header header = new Header(null, Configuration.AppHandle);

            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", header);
            body.Add("message", "header_msg");
            if (entityTypeFilter != null) body.Add("entity_type", entityTypeFilter);

            return MakeRequest<GetEntitiesResponse>(path, body);
        }

        /// <summary>
        /// Makes a call to /certify_beneficial_owner.
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="businessHandle"></param>
        /// <param name="businessPrivateKey"></param>
        /// <param name="memberHandle"></param>
        /// <param name="certificationToken"></param>
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> CertifyBeneficialOwner(string userHandle, string userPrivateKey, string businessHandle, string businessPrivateKey, string memberHandle, string certificationToken)
        {
            var path = "/certify_beneficial_owner";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("app_handle", Configuration.AppHandle);
            header.Add("user_handle", userHandle);
            header.Add("business_handle", businessHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);
            body.Add("member_handle", memberHandle);
            body.Add("certification_token", certificationToken);

            return MakeRequest<BaseResponse>(path, body, userPrivateKey, businessPrivateKey);
        }

        /// <summary>
        /// Makes a call to /certify_business.
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="businessHandle"></param>
        /// <param name="businessPrivateKey"></param>
        /// </summary>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> CertifyBusiness(string userHandle, string userPrivateKey, string businessHandle, string businessPrivateKey)
        {
            var path = "/certify_business";
            Dictionary<String, String> header = new Dictionary<string, string>();
            header.Add("created", EpochUtils.getEpoch().ToString());
            header.Add("app_handle", Configuration.AppHandle);
            header.Add("user_handle", userHandle);
            header.Add("business_handle", businessHandle);

            Dictionary<String, object> body = new Dictionary<string, object>();
            body.Add("header", header);

            return MakeRequest<BaseResponse>(path, body, userPrivateKey, businessPrivateKey);
        }

        /// <sumary>
        /// Cancel a pending transaction under certain circumstances
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="transactionId">The transaction id to cancel</param>
        /// </sumary>
        public ApiResponse<object> CancelTransaction(string userHandle, string userPrivateKey, string transactionId)
        {
            var path = "/cancel_transaction";
            CancelTransactionMsg body = new CancelTransactionMsg(Configuration.AppHandle, userHandle, transactionId);
            return MakeRequest<BaseResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// List the document types for KYC supporting documentation
        /// </summary>
        /// <param name="page">Page number to retrieve. default: 1</param>
        /// <param name="perPage">Number of items per page. default: 20, max: 100</param>
        /// <returns></returns>
        public ApiResponse<object> GetDocumentTypes(int? page = null, int? perPage = null)
        {
            var path = $"/document_types{GetRequestParams(page, perPage)}";
            var body = new HeaderMsg(Configuration.AppHandle);
            return MakeRequest<DocumentTypesResponse>(path, body);
        }

        /// <summary>
        /// Upload supporting documentation for KYC
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="filePath">Full path to the file</param>
        /// <param name="filename">Do not include the file extension</param>
        /// <param name="mimeType">MIME type for one of Supported Image Formats</param>
        /// <param name="documentType">One of Supported Document Types</param>
        /// <param name="identityType">Matching Identity Type for Document Type</param>
        /// <param name="name">Descriptive name of the document</param>
        /// <param name="description">General description of the document</param>
        /// <returns></returns>
        public ApiResponse<object> UploadDocument(string userHandle, string userPrivateKey, string filePath, string filename, string mimeType, string documentType, string identityType, string name = null, string description = null)
        {
            var path = "/documents";
            FileStream file = new FileStream(filePath, FileMode.Open);
            string hash = Signer.HashFile(file);
            file.Close();
            DocumentMsg body = new DocumentMsg(Configuration.AppHandle, userHandle, filename, hash, mimeType, documentType, identityType, name, description);
            return MakeRequest<DocumentResponse>(path, body, filePath, body.MimeType, userPrivateKey);
        }

        /// <summary>
        /// List previously uploaded supporting documentation for KYC
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="startDate">Only return documents created on or after this date.</param>
        /// <param name="endDate">Only return documents created before or on this date.</param>
        /// <param name="docTypes">See Supported Document Types. Use the short form ("name"), not the long form ("label").</param>
        /// <param name="search">Only return documents whose name or filename contains the search value. Partial matches allowed, no wildcards.</param>
        /// <param name="sortBy">One of: name or date</param>
        /// <param name="page">Page number to retrieve. default: 1</param>
        /// <param name="perPage">Number of items per page. default: 20, max: 100</param>
        /// <param name="order">Sort returned items (usually by creation date). Allowed values: asc (default), desc</param>
        /// <returns></returns>
        public ApiResponse<object> ListDocuments(string userHandle, string userPrivateKey, DateTime? startDate = null, DateTime? endDate = null, List<string> docTypes = null, string search = null, string sortBy = null, int? page = null, int? perPage = null, string order = null)
        {
            var path = $"/list_documents{GetRequestParams(page, perPage, order)}";
            ListDocumentsMsg body = new ListDocumentsMsg(Configuration.AppHandle, userHandle, startDate, endDate, docTypes, search, sortBy);
            return MakeRequest<ListDocumentsResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Retrieve a previously uploaded supporting documentation for KYC
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="documentId">The document if to retrieve</param>
        /// <returns></returns>
        public ApiResponse<object> GetDocument(string userHandle, string userPrivateKey, string documentId)
        {
            var path = "/get_document";
            var body = new GetDocumentMsg(Configuration.AppHandle, userHandle, documentId);
            return MakeFileRequest(path, body, userPrivateKey);
        }

        /// <summary>
        /// Delete an existing email, phone number, street address, or identity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="dataType">The type of registration data to delete</param>
        /// <param name="uuid">The uuid of the registration data</param>
        /// <returns></returns>
        public ApiResponse<object> DeleteRegistrationData(string userHandle, string userPrivateKey, RegistrationData dataType, string uuid)
        {
            var path = $"/delete/{dataType.Url}";
            var body = new DeleteRegistrationMsg(Configuration.AppHandle, userHandle, uuid);
            return MakeRequest<BaseResponseWithoutReference>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Add a new email to a registered entity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="email">The new email</param>
        /// <returns></returns>
        public ApiResponse<object> AddEmail(string userHandle, string userPrivateKey, string email)
        {
            var body = new EmailMsg(Configuration.AppHandle, userHandle, email);
            return CallRegistrationData<EmailResponse>("add", RegistrationData.Email, userPrivateKey, body);
        }

        /// <summary>
        /// Add a new phone to a registered entity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="phone">The new phone</param>
        /// <returns></returns>
        public ApiResponse<object> AddPhone(string userHandle, string userPrivateKey, string phone)
        {
            var body = new PhoneMsg(Configuration.AppHandle, userHandle, phone);
            return CallRegistrationData<PhoneResponse>("add", RegistrationData.Phone, userPrivateKey, body);
        }

        /// <summary>
        /// Add a new phone to a registered entity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="phone">The new phone</param>
        /// <param name="smsOptIn"></param>
        /// <returns></returns>
        public ApiResponse<object> AddPhone(string userHandle, string userPrivateKey, string phone, Boolean smsOptIn)
        {
            var body = new PhoneMsg(Configuration.AppHandle, userHandle, phone, null, smsOptIn);
            return CallRegistrationData<PhoneResponse>("add", RegistrationData.Phone, userPrivateKey, body);
        }

        /// <summary>
        /// Add a new identity to a registered entity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="identity">The new identity</param>
        /// <returns></returns>
        public ApiResponse<object> AddIdentity(string userHandle, string userPrivateKey, IdentityMessage identity)
        {
            var body = new IdentityMsg(Configuration.AppHandle, userHandle, identity);
            return CallRegistrationData<IdentityResponse>("add", RegistrationData.Identity, userPrivateKey, body);
        }

        /// <summary>
        /// Add a new address to a registered entity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="address">The new address</param>
        /// <returns></returns>
        public ApiResponse<object> AddAddress(string userHandle, string userPrivateKey, AddressMessage address)
        {
            var body = new AddressMsg(Configuration.AppHandle, userHandle, address);
            return CallRegistrationData<AddressResponse>("add", RegistrationData.Address, userPrivateKey, body);
        }

        /// <summary>
        /// Add a new device fingerprint to a registered entity
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="deviceFingerprint">Iovation device token to be used in verification</param>
        /// <returns></returns>
        public ApiResponse<object> AddDevice(string userHandle, string userPrivateKey, string deviceFingerprint)
        {
            var body = new DeviceMsg(Configuration.AppHandle, userHandle, deviceFingerprint);
            return CallRegistrationData<BaseResponse>("add", RegistrationData.Device, userPrivateKey, body);
        }

        /// <summary>
        /// Update an existing email of a registered entity
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="uuid">The email uuid</param>
        /// <param name="email">The updated email</param>
        /// <returns></returns>
        public ApiResponse<object> UpdateEmail(string userHandle, string userPrivateKey, string uuid, string email)
        {
            var body = new EmailMsg(Configuration.AppHandle, userHandle, email, uuid);
            return CallRegistrationData<EmailResponse>("update", RegistrationData.Email, userPrivateKey, body);
        }

        /// <summary>
        /// Update an existing phone of a registered entity
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="uuid">The phone uuid</param>
        /// <param name="phone">The updated phone</param>
        /// <param name="smsOptIn">optional boolean field. If true, and if app is configured to send SMS messages, sends a confirmation SMS to the passed-in phone number</param>
        /// <returns></returns>
        public ApiResponse<object> UpdatePhone(string userHandle, string userPrivateKey, string uuid, string phone, bool? smsOptIn = null)
        {
            PhoneMsg body = new PhoneMsg(Configuration.AppHandle, userHandle, phone, uuid, smsOptIn);
            return CallRegistrationData<PhoneResponse>("update", RegistrationData.Phone, userPrivateKey, body);
        }

        /// <summary>
        /// Update an existing identity of a registered entity
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="identity">The updated identity</param>
        /// <returns></returns>
        public ApiResponse<object> UpdateIdentity(string userHandle, string userPrivateKey, IdentityMessage identity)
        {
            var body = new IdentityMsg(Configuration.AppHandle, userHandle, identity);
            return CallRegistrationData<IdentityResponse>("update", RegistrationData.Identity, userPrivateKey, body);
        }

        /// <summary>
        /// Update an existing address to a registered entity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="address">The updated address</param>
        /// <returns></returns>
        public ApiResponse<object> UpdateAddress(string userHandle, string userPrivateKey, AddressMessage address)
        {
            var body = new AddressMsg(Configuration.AppHandle, userHandle, address);
            return CallRegistrationData<AddressResponse>("update", RegistrationData.Address, userPrivateKey, body);
        }

        /// <summary>
        /// Update an existing individual entity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="entity">The updated entity information</param>
        /// <returns></returns>
        public ApiResponse<object> UpdateEntity(string userHandle, string userPrivateKey, IndividualEntityMessage entity)
        {
            var body = new IndividualEntityMsg(Configuration.AppHandle, userHandle, entity);
            return CallRegistrationData<IndividualEntityResponse>("update", RegistrationData.Entity, userPrivateKey, body);
        }

        /// <summary>
        /// Update an existing business entity.
        /// </summary>
        /// <param name="userHandle">The user handle</param>
        /// <param name="userPrivateKey">The user's private key</param>
        /// <param name="entity">The updated entity information</param>
        /// <returns></returns>
        public ApiResponse<object> UpdateEntity(string userHandle, string userPrivateKey, BusinessEntityMessage entity)
        {
            var body = new BusinessEntityMsg(Configuration.AppHandle, userHandle, entity);
            return CallRegistrationData<BusinessEntityResponse>("update", RegistrationData.Entity, userPrivateKey, body);
        }

        /// <summary>
        /// An end-user who is attempting to complete the Plaid's authorization needs a Plaid link_token to initiate the process.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="androidPackageName">optional</param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> PlaidLinkToken(string userHandle, string userPrivateKey, string androidPackageName = null)
        {
            PlaidLinkTokenMsg body = new PlaidLinkTokenMsg(userHandle, Configuration.AppHandle, androidPackageName);
            var path = "/plaid_link_token";

            return MakeRequest<PlaidLinkTokenResult>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Deletes a bank account.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <returns>ApiResponse&lt;object&gt; object with the server response</returns>
        public ApiResponse<object> DeleteAccount(string userHandle, string userPrivateKey, string accountName)
        {
            DeleteAccountMsg body = new DeleteAccountMsg(userHandle, Configuration.AppHandle, accountName);
            var path = "/delete_account";

            return MakeRequest<DeleteAccountResult>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Returns whether entity attached to partnered app is verified, not valid, or still pending.
        /// </summary>
        /// <param name="queryAppHandle"></param>
        /// <param name="queryUserHandle"></param>
        /// <returns></returns>
        public ApiResponse<object> CheckPartnerKyc(string queryAppHandle, string queryUserHandle)
        {
            var path = "/check_partner_kyc";
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new BodyHeader
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = Configuration.AppHandle,
                Crypto = "ETH",
                Reference = UuidUtils.GetUuid(),
                Version = "0.2"
            });
            body.Add("query_app_handle", queryAppHandle);
            body.Add("query_user_handle", queryUserHandle);

            return MakeRequest<CheckPartnerKycResponse>(path, body);
        }

        /// <summary>
        /// Updates account name of a bank account.
        /// /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <param name="newAccountName"></param>
        /// <returns></returns>
        public ApiResponse<object> UpdateAccount(string userHandle, string userPrivateKey, string accountName, string newAccountName, bool isActive = true)
        {
            var path = "/update_account";
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new BodyHeader
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = Configuration.AppHandle,
                UserHandle = userHandle,
                Crypto = "ETH",
                Reference = UuidUtils.GetUuid(),
                Version = "0.2"
            });
            body.Add("account_name", accountName);
            body.Add("new_account_name", newAccountName);
            body.Add("active", isActive);

            return MakeRequest<UpdateAccountResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public ApiResponse<object> PlaidUpdateLinkToken(string userHandle, string accountName)
        {
            var path = "/plaid_update_link_token";
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new BodyHeader
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = Configuration.AppHandle,
                UserHandle = userHandle
            });
            body.Add("account_name", accountName);

            return MakeRequest<PlaidUpdateLinkTokenResponse>(path, body);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="userPrivateKey"></param>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public ApiResponse<object> CheckInstantACH(string userHandle, string userPrivateKey, string accountName)
        {
            var path = "/check_instant_ach";
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new BodyHeader
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = Configuration.AppHandle,
                UserHandle = userHandle,
                Reference = UuidUtils.GetUuid()
            });
            body.Add("account_name", accountName);

            return MakeRequest<CheckInstantACHResponse>(path, body, userPrivateKey);
        }

        /// <summary>
        /// Fetch data about institutions and which products they support.
        /// </summary>
        /// <param name="searchFilters"></param>
        /// <returns></returns>
        public ApiResponse<object> GetInstitutions(InstitutionSearchFilters searchFilters = null)
        {
            var path = "/get_institutions";
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("header", new BodyHeader
            {
                Created = EpochUtils.getEpoch(),
                AppHandle = Configuration.AppHandle
            });
            if (searchFilters != null) body.Add("search_filters", searchFilters);

            return MakeRequest<GetInstitutionsResponse>(path, body);
        }

        private ApiResponse<object> CallRegistrationData<T>(string rootPath, RegistrationData dataType, string userPrivateKey, object body)
        {
            var path = $"/{rootPath}/{dataType.Url}";
            return MakeRequest<T>(path, body, userPrivateKey);
        }

        private string GetRequestParams(int? page = null, int? perPage = null, string order = null)
        {
            string requestParams = "";
            if (page.HasValue)
            {
                requestParams += $"?page={page.Value}";
            }
            if (perPage.HasValue)
            {
                if (string.IsNullOrWhiteSpace(requestParams))
                {
                    requestParams += "?";
                }
                else
                {
                    requestParams += "&";
                }
                requestParams += $"per_page={perPage.Value}";
            }
            if (!string.IsNullOrWhiteSpace(order))
            {
                if (string.IsNullOrWhiteSpace(requestParams))
                {
                    requestParams += "?";
                }
                else
                {
                    requestParams += "&";
                }
                requestParams += $"order={order}";
            }
            return requestParams;
        }

        private ApiResponse<object> MakeRequest<T>(string path, object body, string filePath, string contentType, string userPrivateKey)
        {
            string requestBody = SerializationUtil.Serialize(body);
            var headerParams = PrepareHeaders(requestBody, userPrivateKey);

            IRestResponse response = (IRestResponse)Configuration.ApiClient.CallApi(path, Method.POST, requestBody, headerParams, filePath, contentType);

            return GenerateResponseFromJson<T>(response);
        }

        private ApiResponse<object> MakeRequest<T>(string path, object body, string userPrivateKey = null, string businessPrivateKey = null)
        {
            string requestBody = SerializationUtil.Serialize(body);
            var headerParams = PrepareHeaders(requestBody, userPrivateKey, businessPrivateKey);
            string contentType = "application/json";

            IRestResponse response = (IRestResponse)Configuration.ApiClient.CallApi(path, Method.POST, requestBody, headerParams, contentType);

            return GenerateResponseFromJson<T>(response);
        }

        private ApiResponse<object> MakeFileRequest(string path, object body, string userPrivateKey)
        {
            string requestBody = SerializationUtil.Serialize(body);
            var headerParams = PrepareHeaders(requestBody, userPrivateKey);
            string contentType = "application/json";

            IRestResponse response = (IRestResponse)Configuration.ApiClient.CallApi(path, Method.POST, requestBody, headerParams, contentType);

            return GenerateResponseFromBinary(response);
        }

        private Dictionary<string, string> PrepareHeaders(string requestBody, string userPrivateKey, string businessPrivateKey = null)
        {
            var headerParams = new Dictionary<string, string>();

            headerParams.Add("authsignature", Signer.Sign(requestBody, Configuration.PrivateKey));
            if (!string.IsNullOrWhiteSpace(userPrivateKey)) headerParams.Add("usersignature", Signer.Sign(requestBody, userPrivateKey));
            if (!string.IsNullOrWhiteSpace(businessPrivateKey)) headerParams.Add("businesssignature", Signer.Sign(requestBody, businessPrivateKey));

            return headerParams;
        }

        private ApiResponse<object> GenerateResponseFromJson<T>(IRestResponse response)
        {
            int statusCode = (int)response.StatusCode;

            object responseBody;

            if (Configuration.Debug)
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

        private ApiResponse<object> GenerateResponseFromBinary(IRestResponse response)
        {
            int statusCode = (int)response.StatusCode;

            Console.WriteLine(response.Content);

            if (statusCode == 200)
            {
                return new ApiResponse<object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                response.Content,
                true);
            }
            return GenerateResponseFromJson<string>(response);
        }

        private bool GetSuccess(int statusCode, object body)
        {
            if (statusCode != 200) return false;

            if (body.GetType() == typeof(BaseResponse) && (((BaseResponse)body).Status != "SUCCESS" && ((BaseResponse)body).Status != null))
                return false;

            return true;
        }
    }
}
