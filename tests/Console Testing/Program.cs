using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Domain.Data.Network;
using Mx.NET.SDK.Domain.Data.Account;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Domain.SmartContracts;
using Mx.NET.SDK.Core.Domain.Abi;

//var gwProvider = new GatewayProvider(new MultiversxNetworkConfiguration(Network.DevNet));
//var gwNetworkConfig = await NetworkConfig.GetFromNetwork(gwProvider);

//var apiProvider = new ApiProvider(new MultiversxNetworkConfiguration(Network.DevNet));
//var apiNetworkConfig = await NetworkConfig.GetFromNetwork(gwProvider);

var mvxProvider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
//var mvxNetworkConfig = await NetworkConfig.GetFromNetwork(mvxProvider);

//var myProvider = new MyProvider();
//var myNetworkConfig = await NetworkConfig.GetFromNetwork(myProvider);

//var account = new Account(Address.FromBech32("erd1nn5jgka6z8utfnn5z5qccaql9m4ljslm4d9tj4nfc24jtpklw4fqv7eg6m"));
//var account = new Account(Address.FromBech32("erd16nlhrnlm30qkpy8q52u95aaw0gjtx33xmlp62g5p4kj4mje04drq5y2tlw"));

//await account.Sync(mvxProvider);
//await account.Sync(gwProvider);
//await account.Sync(apiProvider);
//await account.Sync(myProvider);

//var accountSC1 = AccountSC.From(await mvxProvider.GetAccount("erd1qqqqqqqqqqqqqpgqgzd8ncx9ntp2cfu5ukwqdyuh2vddgdswx66s638ucp"));
//var accountSC2 = AccountSC.From(await apiProvider.GetAccount("erd1qqqqqqqqqqqqqpgqgzd8ncx9ntp2cfu5ukwqdyuh2vddgdswx66s638ucp"));
//var accountSC3 = AccountSC.From(await myProvider.GetAccount("erd1qqqqqqqqqqqqqpgqgzd8ncx9ntp2cfu5ukwqdyuh2vddgdswx66s638ucp"));
//var accountSC4 = AccountSC.From(await gwProvider.GetAddress("erd1qqqqqqqqqqqqqpgqgzd8ncx9ntp2cfu5ukwqdyuh2vddgdswx66s638ucp"));

//var a = await gwProvider.GetAddress("erd16nlhrnlm30qkpy8q52u95aaw0gjtx33xmlp62g5p4kj4mje04drq5y2tlw");
//var account1 = Account.From(await mvxProvider.GetAccount("erd1ac90uqqqvqg9sgshg6kdgx3hdy8pry5rmasuz0c6myjqg5pgse9qg72y8t"));
//var account2 = Account.From(await apiProvider.GetAccount("erd16nlhrnlm30qkpy8q52u95aaw0gjtx33xmlp62g5p4kj4mje04drq5y2tlw"));
//var account3 = Account.From(await gwProvider.GetAddress("erd16nlhrnlm30qkpy8q52u95aaw0gjtx33xmlp62g5p4kj4mje04drq5y2tlw"));
//var account4 = Account.From(await myProvider.GetAccount("erd16nlhrnlm30qkpy8q52u95aaw0gjtx33xmlp62g5p4kj4mje04drq5y2tlw")); 


//var abi = AbiDefinition.FromFilePath("abi3.json");
//var qw = await SmartContract.QuerySmartContractWithAbiDefinition<VariadicValue>(
//    //myProvider,
//    mvxProvider,
//    //gwProvider,
//    //apiProvider,
//    Address.FromBech32("erd1qqqqqqqqqqqqqpgqfa6uz5umgwftd0s7fzpa249ys757jf6v4drq58wxgj"),
//    abi,
//    "getStrstr");

//var nfts = AccountNFT.From(await apiProvider.GetAccountNFTs("erd16nlhrnlm30qkpy8q52u95aaw0gjtx33xmlp62g5p4kj4mje04drq5y2tlw"));

Console.WriteLine("\nEND PROGRAM...\nPress any key to close.");
Console.ReadKey();