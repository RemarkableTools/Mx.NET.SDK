using Mx.NET.SDK.Provider.Generic;

namespace Mx.NET.SDK.Provider
{
    public interface IGatewayProvider :
        IGenericGatewayProvider,
        Gateway.IGenericProvider,
        Gateway.IAddressesProvider,
        Gateway.ITransactionsProvider,
        Gateway.INetworkProvider,
        Gateway.INodesProvider,
        Gateway.IBlocksProvider,
        Gateway.IQueryVmProvider,
        Gateway.IESDTProvider
    { }
}
