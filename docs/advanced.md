# Advanced usage

The following examples depend on:
* [Mx.NET.SDK](https://github.com/RemarkableTools/Mx.NET.SDK/tree/main/src/Mx.NET.SDK)
* [Mx.NET.SDK.Core](https://github.com/RemarkableTools/Mx.NET.SDK/tree/main/src/Mx.NET.SDK.Core)
* [Mx.NET.SDK.Wallet](https://github.com/RemarkableTools/Mx.NET.SDK/tree/main/src/Mx.NET.SDK.Wallet)

*These examples are using a wallet __signer__ that should not be used in production, only in private!*

---

## 1. Token Transfer

#### In the following example we will create a [`Token Transaction Request`](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/src/Mx.NET.SDK/TransactionsManager/TokenTransactionRequest.cs), sign it and send it to the network
Get the [`MultiversxProvider`](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/src/Mx.NET.SDK/Configuration/MultiversxNetworkConfiguration.cs) instance
```csharp
var provider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
```
Get a valid [`NetworkConfig`](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/src/Mx.NET.SDK/Domain/Data/Network/NetworkConfig.cs) instance
```csharp
var networkConfig = await NetworkConfig.GetFromNetwork(provider);
```
Create a [`Signer`](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/src/Mx.NET.SDK.Wallet/Wallet/WalletSigner.cs) instance by providing the key file and the associated password
```csharp
var filePath = "PATH/TO/KEYFILE.json";
var password = "PASSWORD";
var signer = WalletSigner.FromKeyFile(filePath, password);
```
Set up my Account and Receiver Address
```csharp
var account = Account.From(await provider.GetAccount(signer.GetAddress().Bech32));
var receiverAddress = Address.FromBech32("RECEIVER_ADDRESS");
```
Get a token from network
```csharp
var token = Token.From(await provider.GetToken("BUSD-632f7d"));
```
Create the [`Transaction Request`](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/src/Mx.NET.SDK/Domain/TransactionRequest.cs)
```csharp
var transactionRequest = TokenTransactionRequest.TokenTransfer(
    networkConfig,
    account,
    receiverAddress,
    token.Identifier,
    ESDTAmount.ESDT("100", token.GetESDT()));
```
Use the [`Wallet Methods`](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/src/Mx.NET.SDK.Wallet/WalletMethods.cs) to sign the transaction
```csharp
var signedTransaction = signer.SignTransaction(transactionRequest);
```
POST the transaction to MultiversX API
```csharp
try
{
    var response = await provider.SendTransaction(signedTransaction);
    //other instructions
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
Get the [`Transaction`](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/src/Mx.NET.SDK/Domain/Data/Transaction/Transaction.cs) from response and await for execution to finalize
```csharp
var transaction = Transaction.From(response.TxHash);
await transaction.AwaitExecuted(provider);
Console.WriteLine($"Transaction executed with status {transaction.Status}");
```

---

## 2. Smart Contract interaction
The example is created for the [adder](https://github.com/multiversx/mx-sdk-rs/tree/master/contracts/examples/adder) contract.
#### Create a [`EGLD Transaction Request`](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/src/Mx.NET.SDK/TransactionsManager/EGLDTransactionRequest.cs) to a Smart Contract, sign it and send it to the network
```csharp
try
{
    var transactionRequest = EGLDTransactionRequest.EGLDTransferToSmartContract(
        networkConfig,
        account,
        smartContractAddress,
        ESDTAmount.Zero(),
        "add",
        NumericValue.BigUintValue(10));
    var signedTransaction = signer.SignTransaction(transactionRequest);
    var response = await provider.SendTransaction(signedTransaction);
    var transaction = Transaction.From(response.TxHash);
    await transaction.AwaitExecuted(provider);
    Console.WriteLine($"Transaction executed with status {transaction.Status}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
#### Query smart contract
```csharp
var smartContractAddress = Address.FromBech32("CONTRACT_BECH32_ADDRESS");
var outputType = TypeValue.BigUintTypeValue;
var queryResult = await SmartContract.QuerySmartContract<NumericValue>(provider,
                                                                       smartContractAddress,
                                                                       outputType,
                                                                       "getSum");
Console.WriteLine(queryResult.Number);

// query array from Smart Contract (random example)
var queryArrayResult = await SmartContract.QueryArraySmartContract<Address>(provider,
                                                                            smartContractAddress,
                                                                            TypeValue.AddressValue,
                                                                            "getUsers");
foreach (var user in queryArrayResult)
    Console.WriteLine(user.Bech32);

// more complex reading from Smart Contract storage (random example)
uint day = 1;
var dayRewards = await SmartContract.QueryArraySmartContract<StructValue>(provider,
                                                                          smartContractAddress,
                                                                          TypeValue.StructValue("EsdtTokenPayment", new FieldDefinition[3]
                                                                          {
                                                                              new FieldDefinition("token_identifier", "", TypeValue.TokenIdentifierValue),
                                                                              new FieldDefinition("token_nonce", "", TypeValue.U64TypeValue),
                                                                              new FieldDefinition("amount", "", TypeValue.BigUintTypeValue)
                                                                          }),
                                                                          "getDayRewards",
                                                                          null,
                                                                          NumericValue.U32Value(day));
foreach(var esdt in dayRewards)
    Console.WriteLine($"{esdt.Fields[0].Value} {esdt.Fields[1].Value} {esdt.Fields[2].Value}");
// You can map the StructValue from response to you custom class object for easier usage, if you need
```