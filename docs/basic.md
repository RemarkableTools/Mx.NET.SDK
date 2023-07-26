## Basic usage

#### In the following example we will get an account from network and get all its tokens
```csharp
var provider = new ApiProvider(new ApiNetworkConfiguration(Network.DevNet));

var bech32Address = "BECH32_ADDRESS";
var account = Account.From(await provider.GetAccount(bech32Address));
//Print account balance with 4 decimals
Console.WriteLine($"EGLD balance: {account.Balance.ToCurrencyString(4)}");

var accountTokens = AccountToken.From(await provider.GetAccountTokens(bech32Address));
foreach (var token in accountTokens)
    //Print token and the token balance with all decimals
    Console.WriteLine($"{token.Name}: {token.Balance.ToCurrencyString()}");
```

Example response:
```
EGLD balance: 20.9098 EGLD
TestMTSDT: 999999996648.90376999999999975 MTSDT
WEB: 5000 WEB
```

---

## [Advanced usage](https://github.com/RemarkableTools/Mx.NET.SDK/blob/master/docs/advanced.md) example
- Create a Token transaction request
- Sign and send the transaction
- Create a smart contract transaction
- Query smart contract