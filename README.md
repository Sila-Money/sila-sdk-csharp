# .Net SDK

For using this SDK you will need to use .Net framework 4.6.1 or later.

# Usage

## Installation

Add the SDK from the Nuget Package Manager to your project.

## Initialize the application

```csharp
using SilaAPI.silamoney.client.api;

class SilamoneyApi
{
    SilaApi api = new SilaApi(Environments.SANDBOX,
            privateKey,
            appHandle);
}
```

This sets up the app private key and handle for the SDK to use for signing subsequent requests. The other SDK functionality will not be available until this configuration is completed. The SDK does not store this information outside of the instance that is configured. Private keys are never transmitted over the network or stored outside the scope of this instance.

## User Methods

### Check Handle

Checks if a specific handle is already taken.

```csharp
string userHandle = "user.silamoney.eth";
ApiResponse<object> response =  api.CheckHandle(userHandle);
```

#### Success Response Object 200

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user is available!
```

#### Failure Response Object 200

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // FAILURE
Console.WriteLine(((BaseResponse)response.Data).Message); // user is already taken
```

### Register

Attaches KYC data and specified blockchain address to an assigned handle.

```csharp
User user = new User(userHandle, firstName, lastName, entityName, identityName, phone, email, streetAddress1, streetAddress2, city,
                state, postalCode, cryptoAddress, birthdate);
ApiResponse<object> response = api.Register(user);
```

#### Success Response Object

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user was successfully registered.
```

### Register Business

Attaches KYC data and specified blockchain address to an assigned handle.

```csharp
BusinessUser user = new BusinessUser(userHandle, entityName, identityValue, phone, email, streetAddress1, streetAddress2, city, state, postalCode, cryptoAddress, businessType, businessWebsite, doingBusinessAs, naicsSubcategoryCode);
ApiResponse<object> response = api.Register(user);
```

#### Success Response Object

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user was successfully registered.
```

### Request KYC

Starts KYC verification process on a registered user handle.

#### Normal flow

```csharp
ApiResponse<object> response = api.RequestKYC(userHandle, walletPrivateKey);
```

#### Custom flow
```csharp
ApiResponse<object> response = api.RequestKYC(userHandle, walletPrivateKey, "flow_name");
```

#### Success Response Object

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user submitted for KYC review.
```

### Check KYC

Returns whether the entity attached to the user handle is verified, not valid, or still pending.

```csharp
ApiResponse<object> response = api.CheckKYC(userHandle, walletPrivateKey);
```

#### Success Response Object

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedResponse = (CheckKYCResponse)response.Data;
Console.WriteLine(parsedResponse.Reference); // Random reference number
Console.WriteLine(parsedResponse.Status); // SUCCESS
Console.WriteLine(parsedResponse.Message); // user has passed ID verification!
Console.WriteLine(parsedResponse.EntityType); // individual|business
Console.WriteLine(parsedResponse.VerificationStatus); // passed
Console.WriteLine(parsedResponse.VerificationHistory); // A list of verification results
Console.WriteLine(parsedResponse.ValidKycLevels); // List of kyc levels [DEFAULT, ...]
```

### Link Account

Uses a provided Plaid public token to link a bank account to a verified entity.

#### Plaid verification flow (recomended)

```csharp
ApiResponse<object> response = api.LinkAccount(userHandle, publicToken, walletPrivateKey, accountName, accountId); // Account Name and Account Id parameters are not required 
```

Public token received in the /link/item/create plaid endpoint.

#### Direct account-linking flow (restricted by use-case, contact Sila for approval)

```csharp
ApiResponse<object> response = api.LinkAccountDirect(userHandle, walletPrivateKey, accountNumber, routingNumber, accountType, accountName); // Account Type and Account Name parameters are not required 
```

The only permitted account type is "CHECKING"

#### Success Response Object

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((LinkAccountResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((LinkAccountResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((LinkAccountResponse)response.Data).Message); // Bank account successfully linked.
Console.WriteLine(((LinkAccountResponse)response.Data).AccountName); // Account Name.
Console.WriteLine(((LinkAccountResponse)response.Data).MatchScore);
```

### Get Accounts

Gets basic bank account names linked to a wallet of the user handle.

```csharp
ApiResponse<object> response = api.GetAccounts(userHandle, walletPrivateKey);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((List<Account>)response.Data)[0].AccountLinkStatus); // Account Link Status
Console.WriteLine(((List<Account>)response.Data)[0].AccountName); // Account Name
Console.WriteLine(((List<Account>)response.Data)[0].AccountNumber); // Account Number
Console.WriteLine(((List<Account>)response.Data)[0].AccountStatus); // Account Status
Console.WriteLine(((List<Account>)response.Data)[0].AccountType); // Account Type
Console.WriteLine(((List<Account>)response.Data)[0].Active); // Active
Console.WriteLine(((List<Account>)response.Data)[0].RoutingNumber); // Routing Number
```

### Get Account Balance

Gets bank account balance for a bank account linked with Plaid

```csharp
ApiResponse<object> response = api.GetAccountBalance(userHandle, walletPrivateKey, accountName);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (GetAccountBalanceResponse)response.Data;
Console.WriteLine(parsedData.Success); // TRUE
Console.WriteLine(parsedData.AvailableBalance); // Available balance
Console.WriteLine(parsedData.CurrentBalance); // Current balance
Console.WriteLine(parsedData.MaskedAccountNumber); // Masked account number
Console.WriteLine(parsedData.RoutingNumber); // Routing number
Console.WriteLine(parsedData.AccountName); // Account name
```

### Issue Sila

Debits a specified account and issues tokens to the wallet belonging to the requested handle's.

```csharp
ProcessingType processingType = ProcessingType.Sameday; // Optional
ApiResponse<object> response = api.IssueSila(userHandle, amount, walletPrivateKey, accountName, descriptor, businessUuid, processingType); 
// Account Name is optional but defaults to 'default'.
// Descriptor and Business UUID are optional.
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((TransactionResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((TransactionResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((TransactionResponse)response.Data).Message); // Transaction submitted to processing queue.
Console.WriteLine(((TransactionResponse)response.Data).Descriptor); // Transaction descriptor.
Console.WriteLine(((TransactionResponse)response.Data).TransactionId); // Transaction id.
```

### Transfer Sila

Starts a transfer of the requested amount of SILA to the requested destination handle.

```csharp
ApiResponse<object> response = api.TransferSila(userHandle, amount, destinationHandle, walletPrivateKey, destinationWallet, destinationAddress, descriptor, businessUuid); 
// Destination Wallet and Destination Address are not required. Both must be owned by the Destination Handle
// Descriptor and Business UUID are optional.
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((TransferResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((TransferResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((TransferResponse)response.Data).Message); // Transaction submitted to processing queue.
Console.WriteLine(((TransferResponse)response.Data).Descriptor); // Transaction descriptor.
Console.WriteLine(((TransferResponse)response.Data).TransactionId); // Transaction id.
Console.WriteLine(((TransferResponse)response.Data).DestinationAddress); // The destination wallet address.

```

### Redeem Sila

Burns given the amount of SILA at the handle's wallet address, and credits their named bank account in the equivalent monetary amount.

```csharp
ProcessingType processingType = ProcessingType.Sameday; // Optional
ApiResponse<object> response = api.RedeemSila(userHandle, amount, walletPrivateKey, accountName, descriptor, businessUuid, processingType);
// Account Name is optional but defaults to 'default'.
// Descriptor and Business UUID are optional.
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((TransactionResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((TransactionResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((TransactionResponse)response.Data).Message); // Transaction submitted to processing queue.
Console.WriteLine(((TransactionResponse)response.Data).Descriptor); // Transaction descriptor.
Console.WriteLine(((TransactionResponse)response.Data).TransactionId); // Transaction id.
```

### Get Transactions

Gets the array of the user handle's wallet transactions with detailed status information.

```csharp
ApiResponse<object> response = api.GetTransactions(userHandle, walletPrivateKey, filters);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((GetTransactionsResult)response.Data).Page); // Page Number  
Console.WriteLine(((GetTransactionsResult)response.Data).ReturnedCount); // Pages returned
Console.WriteLine(((GetTransactionsResult)response.Data).Success); // Status of the request
Console.WriteLine(((GetTransactionsResult)response.Data).TotalCount); // Total of transactions returned
Console.WriteLine(((GetTransactionsResult)response.Data).Transactions); // Transactions array
```

### Get Sila Balance

Gets Sila balance for a given blockchain address. This endpoint replaces [Sila Balance](#sila-balance)

```csharp
ApiResponse<object> response = api.GetSilaBalance(walletAddress);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (GetSilaBalanceResponse)response.Data;
Console.WriteLine(parsedData.Success); // True
Console.WriteLine(parsedData.Address); // Wallet address
Console.WriteLine(parsedData.SilaBalance); // Sila tokens
```

### Plaid Sameday Auth

Gest a public token to complete the second phase of Plaid's Sameday Microdeposit authorization

```csharp
ApiResponse<object> response = api.PlaidSameDayAuth(userHandle, walletPrivateKey, accountName);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (PlaidSameDayAuthResponse)response.Data;
Console.WriteLine(parsedData.Status); // "SUCCESS"
Console.WriteLine(parsedData.PublicToken); // Plaid token
Console.WriteLine(parsedData.Message); // Message
```

### Get Wallets

Gets a list of the user handle's wallets with nickname and default details

```csharp
var searchFilters = new WalletSearchFilters(blockchainAddress, blockChainNetwork, nickname, pageNumber, resultsPerPage, sortAscending); // The only BlockChain Network currently supported is ETH.
ApiResponse<object> response = api.GetWallets(userHandle, walletPrivateKey, searchFilters);  // Search Filters are not required.
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (GetWalletsResponse)response.Data;
Console.WriteLine(parsedData.Success); // TRUE
Console.WriteLine(parsedData.Page); // Page number
Console.WriteLine(parsedData.ReturnedCount); // # of wallets retrieve in page
Console.WriteLine(parsedData.TotalCount); // Total # of wallets available
Console.WriteLine(parsedData.TotalPageCount); // Total # of pages available
Console.WriteLine(parsedData.Wallets); // List of wallets
```

### Get Wallet

Gets user handle's wallet details: whitelist status, sila balance

```csharp
ApiResponse<object> response = api.GetWallet(userHandle, walletPrivateKey);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (SingleWalletResponse)response.Data;
Console.WriteLine(parsedData.Success); // TRUE
Console.WriteLine(parsedData.Reference); // Reference
Console.WriteLine(parsedData.IsWhitelisted); // Is Whitelisted?
Console.WriteLine(parsedData.SilaBalance); // # of Sila tokens
Console.WriteLine(parsedData.Wallet); // Wallet details (nickname, default...)
```

### Generate Wallet

Generates a new ETH wallet. This is not an endpoint.

```csharp
UserWallet newWallet = api.GenerateWallet(); // Create new Wallet
newWallet.PrivateKey; // The wallet's private key
newWallet.Address; // The wallet's blockchain address
```

### Register Wallet

#### If you don't have a wallet generated

```csharp
UserWallet newWallet = api.GenerateWallet(); // Create new Wallet
ApiResponse<object> response = api.RegisterWallet(userHandle, registeredWalletPrivateKey, newWallet, nickname);
```

#### If you already have generated a wallet by other means

```csharp
UserWallet existingWallet = new UserWallet(newWalletPrivateKey, newWalletBlockchainAddress);
ApiResponse<object> response = api.RegisterWallet(userHandle, registeredWalletPrivateKey, existingWallet, nickname);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (RegisterWalletResponse)response.Data;
Console.WriteLine(parsedData.Success); // TRUE
Console.WriteLine(parsedData.Reference); // Reference
Console.WriteLine(parsedData.Message); // Message
Console.WriteLine(parsedData.WalletNickname); // The wallet nickname associated
```

### Update Wallet

Updates the wallet's nickname and can set it as the default wallet for /transfer_sila

```csharp
ApiResponse<object> response = api.UpdateWallet(userHandle, walletPrivateKey, nickname, isDefault); // Nickname and Is Default are not required but you must include at least one of them.
```
#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (UpdateWalletResponse)response.Data;
Console.WriteLine(parsedData.Success); // TRUE
Console.WriteLine(parsedData.Message); // Message
Console.WriteLine(parsedData.Wallet); // Wallet details (nickname, default...)
Console.WriteLine(parsedData.Changes); // A list of changes made to the wallet
```

### Delete Wallet

Removes the wallet from the provided user handle. Any deleted wallets can't be readded.

```csharp
ApiResponse<object> response = api.DeleteWallet(userHandle, walletPrivateKey);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (UpdateWalletResponse)response.Data;
Console.WriteLine(parsedData.Success); // TRUE
Console.WriteLine(parsedData.Message); // Message
Console.WriteLine(parsedData.Reference); // Reference
```

### Sila Balance

#### Deprecated - Replaced by [Get Sila Balance](#get-sila-balance)

Gets Sila balance for a given blockchain address.

```csharp
ApiResponse<object> response = api.SilaBalance("https://sandbox.silatokenapi.silamoney.com", walletAddress);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((SilaBalanceResponse)response.Data).SilaBalance); // Sila tokens
```

### Get Business Types

Gets a list of valid business types that can be registered.

```csharp
ApiResponse<object> response = api.GetBusinessTypes();
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (BusinessTypesResponse)response.Data;
parsedData.BusinessTypes; // Business types list
```

### Get Business Roles

Retrieves the list of pre-defined business roles.

```csharp
ApiResponse<object> response = api.GetBusinessRoles();
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (BusinessRolesResponse)response.Data;
parsedData.BusinessRoles; // Business roles list
```

### Get Naics Categories

```csharp
ApiResponse<object> response = api.GetNaicsCategories();
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (NaicsCategoriesResponse)response.Data;
parsedData.NaicsCategories; // Naics categories list
parsedData.NaicsCategories.First().Value; // First Naic category object
```

### Link Business Member

```csharp
ApiResponse<object> response = api.LinkBusinessMember(userHandle, userPrivateKey, businessHandle, businessPrivateKey, businessRole, details, memberHandle, ownershipStake);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (LinkOperationResponse)response.Data;
Console.WriteLine(response.Details); // details
Console.WriteLine(response.Role); // Linkekd business member role
```

### Unlink Business Member

```csharp
ApiResponse<object> response = api.UnlinkBusinessMember(userHandle, userPrivateKey, businessHandle, businessPrivateKey, businessRole);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (LinkOperationResponse)response.Data;
Console.WriteLine(response.Message); // Response message
```

### Certify Beneficial Owner

```csharp
ApiResponse<object> response = api.CertifyBeneficialOwner(userHandle, userPrivateKey, businessHandle, businessPrivateKey, member_handle, certificationToken);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (BaseResponse)response.Data;
Console.WriteLine(response.Message); // Beneficial owner successfully certified
```

### Certify Business

```csharp
ApiResponse<object> response = api.CertifyBusiness(userHandle, privateKey, businessHandle, businessPrivateKey);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (BaseResponse)response.Data;
Console.WriteLine(response.Message); // Business successfully certified
```

### Get Entities

```csharp
ApiResponse<object> response = api.GetEntities();
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedData = (GetEntitiesResponse)response.Data;
response.Entities.Individuals; // Individual entities list
response.Entities.Businesses; // Business entities list
```

### Get Entity
```csharp
ApiResponse<object> response = api.GetEntity(userhandle, privateKey);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedResponse = (GetEntityResponse)response.Data;// Access to entity properties
```

### Cancel Transaction
```csharp
ApiResponse<object> response = api.CancelTransaction(userHandle, privateKey, transactionId);
```

#### Success Object Response
```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedResponse = (BaseResponse)response.Data;
Console.WriteLine(parsedResponse.Status); // SUCCESS
Console.WriteLine(parsedResponse.Success); // true
Console.WriteLine(parsedResponse.Message); // Transaction has been canceled
Console.WriteLine(parsedResponse.Reference); // some-uuid-code
```

### Document Types
```csharp
// page is optional
// perPage is optional
var response = api.GetDocumentTypes(page, perPage);
```

#### Success Object Response
```csharp
Console.WriteLine(response.StatusCode); // 200
var parsedResponse = (DocumentTypesResponse)response.Data;
Console.WriteLine(parsedResponse.Success); // true
Console.WriteLine(parsedResponse.Status); // SUCCESS
Console.WriteLine(parsedResponse.DocumentTypes); // A list of DocumentType
Console.WriteLine(parsedResponse.DocumentTypes[0].Name);
Console.WriteLine(parsedResponse.DocumentTypes[0].Label);
Console.WriteLine(parsedResponse.DocumentTypes[0].IdentityType);
Console.WriteLine(parsedResponse.Pagination); // Pagination information (CurrentPage, ReturnedCount, TotalPages, TotalCount)
Console.WriteLine(parsedResponse.Message); // Document type details returned.
```

### Upload Document
```csharp
// Name is optional
// Description is optional
var response = api.UploadDocument(userHandle, privateKey, filepath, filename, mimeType, documentType, identityType, name, description);
```

#### Success Object Response
```csharp
Console.WriteLine(200, response.StatusCode);
var parsedResponse = (DocumentResponse)response.Data;
Console.WriteLine(parsedResponse.Success); // true
Console.WriteLine(parsedResponse.Status); // SUCCESS
Console.WriteLine(parsedResponse.Message); // File uploaded successfully
Console.WriteLine(parsedResponse.ReferenceId); // some-uuid-code
Console.WriteLine(parsedResponse.DocumentId); // other-uuid-code
```
