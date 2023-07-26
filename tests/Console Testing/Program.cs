using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Domain.Data.Network;

//var gwProvider = new GatewayProvider(new GatewayNetworkConfiguration(Network.DevNet));
var apiProvider = new ApiProvider(new ApiNetworkConfiguration(Network.DevNet));
var networkConfig = await NetworkConfig.GetFromNetwork(apiProvider);



Console.WriteLine("\nEND PROGRAM...\nPress any key to close.");
Console.ReadKey();
