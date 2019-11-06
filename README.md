# Sila C# & .Net SDK
For this SDK you will need to use .Net framework 4.6.1 or later.

## Usage

### Installation
Add the SDK from the Nuget Package Manager to your project.

### Initialize the application
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

#### Check Handle
Checks if a specific handle is already taken.
```csharp
string userHandle = "user.silamoney.eth";
ApiResponse<object> response = api.CheckHandle(userHandle);
```

##### Success Response Object 200
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user is available!
```

##### Failure Response Object 200
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // FAILURE
Console.WriteLine(((BaseResponse)response.Data).Message); // user is already taken
```

#### Register
Attaches KYC data and specified blockchain address to an assigned handle.
```csharp
User user = new User(userHandle, firstName, lastName, entityName,
identityName, phone, email, streetAddress1, streetAddress2, city,
 state, postalCode, cryptoAddress, birthdate);
ApiResponse<object> response = api.Register(user);
```

##### Success Response Object
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user was successfully registered.
```

#### RequestKYC
Starts KYC verification process on a registered user handle.
```csharp
ApiResponse<object> response = api.RequestKYC(userHandle,
userPrivateKey);
```

##### Success Response Object
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user submitted for KYC review.
```

#### CheckKYC
Returns whether the entity attached to the user handle is verified, not valid, or still pending.
```csharp
ApiResponse<object> response = api.CheckKYC(userHandle, userPrivateKey);
```

##### Success Response Object
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // user has passed ID verification!
```

#### LinkAccount
Uses a provided Plaid public token to link a bank account to a verified entity.
```csharp
ApiResponse<object> response = api.LinkAccount(userHandle, publicToken,
userPrivateKey);
```
Public token received in the /link/item/create plaid endpoint.

##### Success Response Object
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // Bank account successfully linked.
```

#### GetAccounts
```csharp
Gets basic bank account names linked to user handle.
ApiResponse<object> response = api.GetAccounts(userHandle,
userPrivateKey);
```

##### Success Object Response
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((List<Account>)response.Data)[0].AccountName); // Account Name
Console.WriteLine(((List<Account>)response.Data)[0].AccountNumber); // Account Number
Console.WriteLine(((List<Account>)response.Data)[0].AccountStatus); // Account Status
Console.WriteLine(((List<Account>)response.Data)[0].AccountType); // Account Type
```

#### IssueSila
Debits a specified account and issues tokens to the address belonging to the requested handle.
```csharp
ApiResponse<object> response = api.IssueSila(userHandle, amount,
userPrivateKey);
```

##### Success Object Response
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // Transaction submitted to processing queue.
```

#### TransferSila
Starts a transfer of the requested amount of SILA to the requested destination handle.
```csharp
ApiResponse<object> response = api.TransferSila(userHandle, amount,
destinationHandle, userPrivateKey);
```

##### Success Object Response
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // Transaction submitted to processing queue.
```

#### RedeemSila
Burns given the amount of SILA at the handle's blockchain address and credits their named bank account in the equivalent monetary amount.
```csharp
ApiResponse<object> response = api.RedeemSila(userHandle, amount,
userPrivateKey);
```

##### Success Object Response
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((BaseResponse)response.Data).Reference); // Random reference number
Console.WriteLine(((BaseResponse)response.Data).Status); // SUCCESS
Console.WriteLine(((BaseResponse)response.Data).Message); // Transaction submitted to processing queue.
```

#### GetTransactions
Gets the array of user handle's transactions with detailed status information.
```csharp
ApiResponse<object> response = api.GetTransactions(userHandle,
userPrivateKey, filters);
```

##### Success Object Response
```csharp
Console.WriteLine(response.StatusCode); // 200
Console.WriteLine(((GetTransactionsResult)response.Data).Page); // Page Number
Console.WriteLine(((GetTransactionsResult)response.Data).ReturnedCount); // Pages returned
Console.WriteLine(((GetTransactionsResult)response.Data).Success); // Status of the request
Console.WriteLine(((GetTransactionsResult)response.Data).TotalCount); // Total of transactions returned
Console.WriteLine(((GetTransactionsResult)response.Data).Transactions); // Transactions array
```