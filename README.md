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
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user has passed ID verification!
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
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // Bank account successfully linked.
```

### Get Accounts

Gets basic bank account names linked to a wallet of the user handle.

```csharp
ApiResponse<object> response = api.GetAccounts(userHandle, walletPrivateKey);
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((List<Account>)response.Data)[0].AccountName); // Account Name
Console.WriteLine(((List<Account>)response.Data)[0].AccountNumber); // Account Number
Console.WriteLine(((List<Account>)response.Data)[0].AccountStatus); // Account Status
Console.WriteLine(((List<Account>)response.Data)[0].AccountType); // Account Type
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
Console.WriteLine(parsedData.Status); // SUCCESS
Console.WriteLine(parsedData.AvailableBalance); // Available balance
Console.WriteLine(parsedData.CurrentBalance); // Current balance
Console.WriteLine(parsedData.MaskedAccountNumber); // Masked account number
Console.WriteLine(parsedData.RoutingNumber); // Routing number
Console.WriteLine(parsedData.AccountName); // Account name
```

### Issue Sila

Debits a specified account and issues tokens to the wallet belonging to the requested handle's.

```csharp
ApiResponse<object> response = api.IssueSila(userHandle, amount, walletPrivateKey, accountName); // Account Name is optional but defaults to 'default'.
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // Transaction submitted to processing queue.
```

### Transfer Sila

Starts a transfer of the requested amount of SILA to the requested destination handle.

```csharp
ApiResponse<object> response = api.TransferSila(userHandle, amount, destinationHandle, walletPrivateKey, destinationWallet, destinationAddress); // Destination Wallet and Destination Address are not required. Both must be owned by the Destination Handle
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // Transaction submitted to processing queue.
```

### Redeem Sila

Burns given the amount of SILA at the handle's wallet address, and credits their named bank account in the equivalent monetary amount.

```csharp
ApiResponse<object> response = api.RedeemSila(userHandle, amount, walletPrivateKey, accountName); // Account Name is optional but defaults to 'default'.
```

#### Success Object Response

```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // Transaction submitted to processing queue.
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