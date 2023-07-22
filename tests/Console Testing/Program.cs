using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Configuration;

var provider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));



Console.WriteLine("\nEND PROGRAM...\nPress any key to close.");
Console.ReadKey();