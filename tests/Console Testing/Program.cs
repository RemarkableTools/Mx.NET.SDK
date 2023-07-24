using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Domain.Data.Accounts;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Domain.SmartContracts;
using Mx.NET.SDK.Core.Domain.Abi;
using System.Security.Principal;

//var provider = new MultiversxProviderHo(new MultiversxNetworkConfiguration(Network.DevNet));

var gwProvider = new GatewayProvider(new GatewayNetworkConfiguration(Network.DevNet));
//IMultiversxProvider mvxProvider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
var apiProvider = new ApiProvider(new ApiNetworkConfiguration(Network.DevNet));

//await gwProvider.Get<string>("gerh");
//await mvxProvider.Get<string>("gerh");
//await mvxProvider.GetGeneric<string>("gerh");


//await mvxProvider.GetMvxTransaction("");

var account = new Account(Address.FromBech32(""));
await account.Sync(gwProvider);
await account.SyncGuardian(gwProvider);
await account.SyncWithGuardian(gwProvider);
await account.Sync(apiProvider);

//await SmartContract.QuerySmartContract<VariadicValue>((IGatewayProvider)mvxProvider, Address.FromBech32(""), new TypeValue[] { TypeValue.U16TypeValue }, "");

var abi = AbiDefinition.FromFilePath("abi3.json");
var tuple = await SmartContract.QuerySmartContractWithAbiDefinition<TupleValue>(
    //(IGatewayProvider)mvxProvider,
    gwProvider,
    Address.From("erd1qqqqqqqqqqqqqpgqfa6uz5umgwftd0s7fzpa249ys757jf6v4drq58wxgj"),
    abi,
    "getTuple");
var tupleList = tuple.ToObject<Tuple<ulong, bool>>();

Console.WriteLine("\nEND PROGRAM...\nPress any key to close.");
Console.ReadKey();
