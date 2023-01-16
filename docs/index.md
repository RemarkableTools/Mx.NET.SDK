# [Documentation](./index.md)

### About SDK
The library is a tool to query the MultiversX API or MultiversX Gateway and retrieve infromation about Network, Account, NFTs, Tokens, MetaESDTs, Smart Contract and so on.

---

### Quick start guide
Define the network provider which can be MainNet/DevNet/TestNet
```csharp
var provider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
```
With this provider you can query the MultiversX API data like in the following examples:
```csharp
var networkConfig = await NetworkConfig.GetFromNetwork(provider);
var account = Account.From(await provider.GetAccount("erd1sdslvlxvfnnflzj42l8czrcngq3xjjzkjp3rgul4ttk6hntr4qdsv6sets"));
var transaction = Transaction.From(await provider.GetTransaction("0a94708e9653b79665ba41a6292ec865ab09e51a32be4b96b6f76ba272665f01"));
var nft = NFT.From(await provider.GetNFT("OGAVNGR-1ec41f-01"));
var token = Token.From(await provider.GetToken("MEX-455c57"));
```

---

## [Basic usage](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/docs/basic.md) example
- Get an account from network
- Read all tokens from account

## [Advanced usage](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/docs/advanced.md) example
- Create a Token transaction request
- Sign and send the transaction
- Create a smart contract transaction
- Query smart contract