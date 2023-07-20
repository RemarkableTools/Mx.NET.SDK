﻿namespace Mx.NET.SDK.Provider
{
    public interface IApiProvider :
        API.IGenericProvider,
        API.IAccountsProvider,
        API.IBlocksProvider,
        API.ICollectionsProvider,
        API.INetworkProvider,
        API.INftsProvider,
        API.ITokensProvider,
        API.ITransactionsProvider,
        API.IUsernamesProvider,
        API.IxExchangeProvider
    { }
}