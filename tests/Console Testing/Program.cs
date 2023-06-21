using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Domain.Data.Network;

var provider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
var networkConfig = await NetworkConfig.GetFromNetwork(provider);



Console.WriteLine("\nEND PROGRAM...\nPress any key to close.");
Console.ReadKey();