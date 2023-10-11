# [Documentation](./index.md)

### About SDK
The library is a tool to query the MultiversX API or MultiversX Gateway and retrieve infromation about Network, Account, NFTs, Tokens, MetaESDTs, Smart Contract and so on.

---

### Quick start guide
Define the network provider which can be MainNet/DevNet/TestNet
```csharp
IApiProvider provider = new ApiProvider(new ApiNetworkConfiguration(Network.DevNet));
//OR
//IGatewayProvider provider = new GatewayProvider(new GatewayNetworkConfiguration(Network.DevNet));
```
Or use your own network provider URL or Headers
```csharp
IApiProvider customProvider1 = new ApiProvider(new ApiNetworkConfiguration(Network.DevNet, new Uri("https://your-custom-devnet-uri.com")));
//OR
IApiProvider customProvider2 = new ApiProvider(new ApiNetworkConfiguration(Network.DevNet, new Uri("https://your-custom-devnet-uri.com")),
                                      new Dictionary<string, string>()
                                      {
                                          {"headerKey", "headerValue" }
                                      });
```
With this provider you can query the MultiversX API data like in the following examples:
```csharp
// You can integrate intructions in Try..Catch block

var networkConfig = await NetworkConfig.GetFromNetwork(provider);
var account = Account.From(await provider.GetAccount("erd1sdslvlxvfnnflzj42l8czrcngq3xjjzkjp3rgul4ttk6hntr4qdsv6sets"));
var transaction = Transaction.From(await provider.GetTransaction("0a94708e9653b79665ba41a6292ec865ab09e51a32be4b96b6f76ba272665f01"));
var nft = NFT.From(await provider.GetNFT("OGAVNGR-1ec41f-01"));
var token = Token.From(await provider.GetToken("MEX-455c57"));
```
Other examples:
```csharp
var amount1 = ESDTAmount.ESDT("1000", ESDT.TOKEN("ABC", "ABC-123456", 18)); //18 decimals are added at the end
Console.WriteLine(amount1.ToCurrencyString()); // 1000 ABC

var amount2 = ESDTAmount.From("1000", ESDT.TOKEN("ABC", "ABC-123456", 18)); //'From' means you need to add the decimals
Console.WriteLine(amount2.ToCurrencyString()); // 0.000000000000001 ABC
```
Use the following classes to create transactions:
- **Mx.NET.SDK.TransactionsManager.EGLDTransactionRequest** `EGLD operations`
- **Mx.NET.SDK.TransactionsManager.TokenTransactionRequest** `Token operations`
- **Mx.NET.SDK.TransactionsManager.ESDTTransactionRequest** `NFT/SFT/MetaESDT operations`
- **Mx.NET.SDK.TransactionsManager.SmartContractTransactionRequest** `Smart Contract operations`
- **Mx.NET.SDK.TransactionsManager.CommonTransactionRequest** `Other common operations`

---

## [Basic usage](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/docs/basic.md) example
- Get an account from network
- Read all tokens from account

## [Advanced usage](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/docs/advanced.md) example
- Create a Token transaction request
- Sign and send the transaction
- Create a smart contract transaction
- Query smart contract
