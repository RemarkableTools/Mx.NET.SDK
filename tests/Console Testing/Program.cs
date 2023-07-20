using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Domain.Data.Network;

var gwProvider = new GatewayProvider(new MultiversxNetworkConfiguration(Network.DevNet));
var gwNetworkConfig = await NetworkConfig.GetFromNetwork(gwProvider);

var apiPovider = new ApiProvider(new MultiversxNetworkConfiguration(Network.DevNet));
var apiNetworkConfig = await NetworkConfig.GetFromNetwork(gwProvider);

//var mvxProvider = new MultiversxProvider(...)

Console.WriteLine("\nEND PROGRAM...\nPress any key to close.");
Console.ReadKey();