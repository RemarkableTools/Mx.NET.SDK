using System.Threading.Tasks;
using System.Collections.Generic;
using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Provider.Dtos.Gateway.Addresses;
using Mx.NET.SDK.Provider.Dtos.Gateway.Transactions;
using Mx.NET.SDK.Provider.Dtos.Gateway.Network;
using Mx.NET.SDK.Provider.Dtos.Gateway.Blocks;
using Mx.NET.SDK.Provider.Dtos.Gateway.Query;
using Mx.NET.SDK.Provider.Dtos.Gateway.ESDTs;
using Mx.NET.SDK.Provider.Dtos.API.Accounts;
using Mx.NET.SDK.Provider.Dtos.API.Collections;
using Mx.NET.SDK.Provider.Dtos.API.Network;
using Mx.NET.SDK.Provider.Dtos.API.NFTs;
using Mx.NET.SDK.Provider.Dtos.API.xExchange;
using Mx.NET.SDK.Provider.Dtos.API.Common;
using Mx.NET.SDK.Provider.Dtos.API.Tokens;

namespace Mx.NET.SDK.Provider
{
    //public class MultiversxProviderHo : IProvider
    //{
    //    private readonly IGatewayProvider gatewayProvider;
    //    private readonly IApiProvider apiProvider;

    //    public readonly MultiversxNetworkConfiguration NetworkConfiguration;

    //    public MultiversxProviderHo(MultiversxNetworkConfiguration configuration)
    //    {
    //        NetworkConfiguration = configuration;

    //        gatewayProvider = new GatewayProvider(configuration);
    //        apiProvider = new ApiProvider(configuration);
    //    }

    //    #region Gateway

    //    #region genericGateway

    //    public async Task<TR> Get<TR>(string requestUri)
    //    {
    //        return await gatewayProvider.Get<TR>(requestUri);
    //    }

    //    public async Task<TR> Post<TR>(string requestUri, object requestContent)
    //    {
    //        return await gatewayProvider.Post<TR>(requestUri, requestContent);
    //    }

    //    #endregion

    //    #region address

    //    public async Task<AddressDataDto> GetAddress(string address)
    //    {
    //        return await gatewayProvider.GetAddress(address);
    //    }

    //    public async Task<AddressGuardianDataDto> GetAddressGuardianData(string address)
    //    {
    //        return await gatewayProvider.GetAddressGuardianData(address);
    //    }

    //    public async Task<StorageValueDto> GetStorageValue(string address, string key, bool isHex = false)
    //    {
    //        return await gatewayProvider.GetStorageValue(address, key, isHex);
    //    }

    //    public async Task<AllStorageDto> GetAllStorageValues(string address)
    //    {
    //        return await gatewayProvider.GetAllStorageValues(address);
    //    }

    //    #endregion

    //    #region blocks

    //    public async Task<BlockDto> GetBlockByNonce(long nonce, long shard, bool withTxs = false)
    //    {
    //        return await gatewayProvider.GetBlockByNonce(nonce, shard, withTxs);
    //    }

    //    public async Task<BlockDto> GetBlockByHash(string hash, long shard, bool withTxs = false)
    //    {
    //        return await gatewayProvider.GetBlockByHash(hash, shard, withTxs);
    //    }

    //    public async Task<InternalBlockDto> GetInternalBlockNonce(long nonce)
    //    {
    //        return await gatewayProvider.GetInternalBlockNonce(nonce);
    //    }

    //    public async Task<InternalBlockDto> GetInternalBlockHash(string hash)
    //    {
    //        return await gatewayProvider.GetInternalBlockHash(hash);
    //    }

    //    #endregion

    //    #region esdt

    //    public async Task<EsdtTokenDataDto> GetEsdtTokens(string address)
    //    {
    //        return await gatewayProvider.GetEsdtTokens(address);
    //    }

    //    public async Task<EsdtTokenData> GetEsdtToken(string address, string tokenIdentifier)
    //    {
    //        return await gatewayProvider.GetEsdtToken(address, tokenIdentifier);
    //    }

    //    #endregion

    //    #region network

    //    public async Task<NetworkConfigDataDto> GetNetworkConfig()
    //    {
    //        return await Get<NetworkConfigDataDto>("network/config");
    //        //return await GetNetworkConfig();
    //    }

    //    public async Task<NetworkEconomicsDataDto> GetNetworkEconomics()
    //    {
    //        return await gatewayProvider.GetNetworkEconomics();
    //    }

    //    public async Task<ShardStatusDto> GetShardStatus(long shard)
    //    {
    //        return await gatewayProvider.GetShardStatus(shard);
    //    }

    //    #endregion

    //    #region nodes



    //    #endregion

    //    #region queryVM

    //    public async Task<QueryVmDto> QueryVm(QueryVmRequestDto queryVmRequestDto)
    //    {
    //        return await Post<QueryVmDto>("vm-values/query", queryVmRequestDto);
    //        //return await QueryVm(queryVmRequestDto);
    //    }

    //    #endregion

    //    #region transactions

    //    public async Task<TransactionResponseDto> SendTransaction(TransactionRequestDto transactionRequest)
    //    {
    //        return await Post<TransactionResponseDto>("transaction/send", transactionRequest);
    //        //return await SendTransaction(transactionRequestDto);
    //    }

    //    public async Task<MultipleTransactionsResponseDto> SendTransactions(TransactionRequestDto[] transactionsRequest)
    //    {
    //        return await Post<MultipleTransactionsResponseDto>("transaction/send-multiple", transactionsRequest);
    //        //return await SendTransactions(transactionsRequestDto);
    //    }

    //    public async Task<TransactionCostResponseDto> GetTransactionCost(TransactionRequestDto transactionRequestDto)
    //    {
    //        return await gatewayProvider.GetTransactionCost(transactionRequestDto);
    //    }

    //    public async Task<TransactionDto> GetTransactionDetails(string txHash)
    //    {
    //        return await gatewayProvider.GetTransaction(txHash);
    //    }

    //    #endregion

    //    #endregion

    //    #region API

    //    #region genericApi

    //    public async Task<TR> GetApi<TR>(string requestUri)
    //    {
    //        return await apiProvider.Get<TR>(requestUri);
    //    }

    //    public async Task<TR> PostApi<TR>(string requestUri, object requestContent)
    //    {
    //        return await apiProvider.Post<TR>(requestUri, requestContent);
    //    }

    //    #endregion

    //    #region accounts

    //    public async Task<Dtos.API.Accounts.AccountDto> GetAccount(string address)
    //    {
    //        return await GetApi<Dtos.API.Accounts.AccountDto>($"accounts/{address}?withGuardianInfo=true");
    //        //return await apiProvider.GetAccount(address);
    //    }

    //    public async Task<AccountTokenDto[]> GetAccountTokens(string address, int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountTokens(address, size, from, parameters);
    //    }

    //    public async Task<AccountToken[]> GetAccountTokens<AccountToken>(string address, int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountTokens<AccountToken>(address, size, from, parameters);
    //    }

    //    public async Task<string> GetAccountTokensCount(string address)
    //    {
    //        return await apiProvider.GetAccountTokensCount(address);
    //    }

    //    public async Task<AccountTokenDto> GetAccountToken(string address, string tokenIdentifier)
    //    {
    //        return await apiProvider.GetAccountToken(address, tokenIdentifier);
    //    }

    //    public async Task<Token> GetAccountToken<Token>(string address, string tokenIdentifier)
    //    {
    //        return await apiProvider.GetAccountToken<Token>(address, tokenIdentifier);
    //    }

    //    public async Task<AccountCollectionRoleDto[]> GetAccountCollectionsRole(string address, int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountCollectionsRole(address, size, from, parameters);
    //    }

    //    public async Task<string> GetAccountCollectionsRoleCount(string address, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountCollectionsRoleCount(address, parameters);
    //    }

    //    public async Task<AccountCollectionRoleDto> GetAccountCollectionRole(string address, string collectionIdentifier)
    //    {
    //        return await apiProvider.GetAccountCollectionRole(address, collectionIdentifier);
    //    }

    //    public async Task<AccountTokenRoleDto[]> GetAccountTokensRole(string address, int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountTokensRole(address, size, from, parameters);
    //    }

    //    public async Task<string> GetAccountTokensRoleCount(string address, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountTokensRoleCount(address, parameters);
    //    }

    //    public async Task<AccountTokenRoleDto> GetAccountTokenRole(string address, string tokenIdentifier)
    //    {
    //        return await apiProvider.GetAccountTokenRole(address, tokenIdentifier);
    //    }

    //    public async Task<AccountNftDto[]> GetAccountNFTs(string address, int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountNFTs(address, size, from, parameters);
    //    }

    //    public async Task<NFT[]> GetAccountNFTs<NFT>(string address, int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountNFTs<NFT>(address, size, from, parameters);
    //    }

    //    public async Task<string> GetAccountNFTsCount(string address, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountNFTsCount(address, parameters);
    //    }

    //    public async Task<AccountNftDto> GetAccountNFT(string address, string nftIdentifier)
    //    {
    //        return await apiProvider.GetAccountNFT(address, nftIdentifier);
    //    }

    //    public async Task<NFT> GetAccountNFT<NFT>(string address, string nftIdentifier)
    //    {
    //        return await apiProvider.GetAccountNFT<NFT>(address, nftIdentifier);
    //    }

    //    public async Task<AccountMetaESDTDto[]> GetAccountMetaESDTs(string address, int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountMetaESDTs(address, size, from, parameters);
    //    }

    //    public async Task<MetaESDT[]> GetAccountMetaESDTs<MetaESDT>(string address, int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountMetaESDTs<MetaESDT>(address, size, from, parameters);
    //    }

    //    public async Task<string> GetAccountMetaESDTsCount(string address, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetAccountMetaESDTsCount(address, parameters);
    //    }

    //    public async Task<AccountMetaESDTDto> GetAccountMetaESDT(string address, string metaEsdtIdentifier)
    //    {
    //        return await apiProvider.GetAccountMetaESDT(address, metaEsdtIdentifier);
    //    }

    //    public async Task<MetaESDT> GetAccountMetaESDT<MetaESDT>(string address, string metaEsdtIdentifier)
    //    {
    //        return await apiProvider.GetAccountMetaESDT<MetaESDT>(address, metaEsdtIdentifier);
    //    }

    //    public async Task<AccountSCStakeDto[]> GetAccountStake(string address)
    //    {
    //        return await apiProvider.GetAccountStake(address);
    //    }

    //    public async Task<AccountContractDto[]> GetAccountContracts(string address)
    //    {
    //        return await apiProvider.GetAccountContracts(address);
    //    }

    //    public async Task<string> GetAccountContractsCount(string address)
    //    {
    //        return await apiProvider.GetAccountContractsCount(address);
    //    }

    //    public async Task<AccountHistoryDto[]> GetAccountHistory(string address, int size = 100, int from = 0)
    //    {
    //        return await apiProvider.GetAccountHistory(address, size, from);
    //    }

    //    public async Task<AccountHistoryTokenDto[]> GetAccountHistoryToken(string address, string tokenIdentifier, int size = 100, int from = 0)
    //    {
    //        return await apiProvider.GetAccountHistoryToken(address, tokenIdentifier, size, from);
    //    }

    //    #endregion

    //    #region blocks

    //    public async Task<Dtos.API.Blocks.BlocksDto[]> GetBlocks(int size = 25, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetBlocks(size, from, parameters);
    //    }

    //    public async Task<Blocks[]> GetBlocks<Blocks>(int size = 25, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetBlocks<Blocks>(size, from, parameters);
    //    }

    //    public async Task<string> GetBlocksCount(Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetBlocksCount(parameters);
    //    }

    //    public async Task<Dtos.API.Blocks.BlockDto> GetBlock(string blockHash)
    //    {
    //        return await apiProvider.GetBlock(blockHash);
    //    }

    //    public async Task<Block> GetBlock<Block>(string blockHash)
    //    {
    //        return await apiProvider.GetBlock<Block>(blockHash);
    //    }

    //    #endregion

    //    #region collections

    //    public async Task<CollectionDto[]> GetCollections(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetCollections(size, from, parameters);
    //    }

    //    public async Task<Collection[]> GetCollections<Collection>(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetCollections<Collection>(size, from, parameters);
    //    }

    //    public async Task<string> GetCollectionsCount(Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetCollectionsCount(parameters);
    //    }

    //    public async Task<CollectionDto> GetCollection(string collectionIdentifier)
    //    {
    //        return await apiProvider.GetCollection(collectionIdentifier);
    //    }

    //    public async Task<Collection> GetCollection<Collection>(string collectionIdentifier)
    //    {
    //        return await apiProvider.GetCollection<Collection>(collectionIdentifier);
    //    }

    //    #endregion

    //    #region network

    //    public async Task<Dtos.API.Network.NetworkEconomicsDto> GetNetworkEconomicsApi()
    //    {
    //        return await apiProvider.GetNetworkEconomics();
    //    }

    //    public async Task<NetworkStatsDto> GetNetworkStats()
    //    {
    //        return await apiProvider.GetNetworkStats();
    //    }

    //    #endregion

    //    #region nfts

    //    public async Task<NFTDto[]> GetNFTs(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetNFTs(size, from, parameters);
    //    }

    //    public async Task<NFT[]> GetNFTs<NFT>(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetNFTs<NFT>(size, from, parameters);
    //    }

    //    public async Task<string> GetNFTsCount(Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetNFTsCount(parameters);
    //    }

    //    public async Task<MetaESDTDto[]> GetMetaESDTs(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetMetaESDTs(size, from, parameters);
    //    }

    //    public async Task<MetaESDT[]> GetMetaESDTs<MetaESDT>(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetMetaESDTs<MetaESDT>(size, from, parameters);
    //    }

    //    public async Task<string> GetMetaESDTsCount(Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetMetaESDTsCount(parameters);
    //    }

    //    public async Task<NFTDto> GetNFT(string nftIdentifier)
    //    {
    //        return await apiProvider.GetNFT(nftIdentifier);
    //    }

    //    public async Task<NFT> GetNFT<NFT>(string nftIdentifier)
    //    {
    //        return await apiProvider.GetNFT<NFT>(nftIdentifier);
    //    }

    //    public async Task<MetaESDTDto> GetMetaESDT(string metaEsdtIdentifier)
    //    {
    //        return await apiProvider.GetMetaESDT(metaEsdtIdentifier);
    //    }

    //    public async Task<MetaESDT> GetMetaESDT<MetaESDT>(string metaEsdtIdentifier)
    //    {
    //        return await apiProvider.GetMetaESDT<MetaESDT>(metaEsdtIdentifier);
    //    }

    //    public async Task<AddressBalanceDto[]> GetNFTAccounts(string nftIdentifier, int size = 100, int from = 0)
    //    {
    //        return await apiProvider.GetNFTAccounts(nftIdentifier, size, from);
    //    }

    //    public async Task<string> GetNFTAccountsCount(string nftIdentifier)
    //    {
    //        return await apiProvider.GetNFTAccountsCount(nftIdentifier);
    //    }

    //    public async Task<AddressBalanceDto[]> GetMetaESDTAccounts(string metaEsdtIdentifier, int size = 100, int from = 0)
    //    {
    //        return await apiProvider.GetMetaESDTAccounts(metaEsdtIdentifier, size, from);
    //    }

    //    public async Task<string> GetMetaESDTAccountsCount(string metaEsdtIdentifier)
    //    {
    //        return await apiProvider.GetMetaESDTAccountsCount(metaEsdtIdentifier);
    //    }

    //    #endregion

    //    #region tokens

    //    public async Task<TokenDto[]> GetTokens(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetTokens(size, from, parameters);
    //    }

    //    public async Task<Token[]> GetTokens<Token>(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetTokens<Token>(size, from, parameters);
    //    }

    //    public async Task<string> GetTokensCount(Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetTokensCount(parameters);
    //    }

    //    public async Task<TokenDto> GetToken(string tokenIdentifier)
    //    {
    //        return await apiProvider.GetToken(tokenIdentifier);
    //    }

    //    public async Task<Token> GetToken<Token>(string tokenIdentifier)
    //    {
    //        return await apiProvider.GetToken<Token>(tokenIdentifier);
    //    }

    //    public async Task<AddressBalanceDto[]> GetTokenAccounts(string tokenIdentifier, int size = 100, int from = 0)
    //    {
    //        return await apiProvider.GetTokenAccounts(tokenIdentifier, size, from);
    //    }

    //    public async Task<string> GetTokenAccountsCount(string tokenIdentifier)
    //    {
    //        return await apiProvider.GetTokenAccountsCount(tokenIdentifier);
    //    }

    //    #endregion

    //    #region transactions

    //    public async Task<Dtos.API.Transactions.TransactionDto[]> GetTransactions(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetTransactions(size, from, parameters);
    //    }

    //    public async Task<Transaction[]> GetTransactions<Transaction>(int size = 100, int from = 0, Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetTransactions<Transaction>(size, from, parameters);
    //    }


    //    public async Task<string> GetTransactionsCount(Dictionary<string, string> parameters = null)
    //    {
    //        return await apiProvider.GetTransactionsCount(parameters);
    //    }

    //    public async Task<Dtos.API.Transactions.TransactionDto> GetTransaction(string txHash)
    //    {
    //        return await GetApi<Dtos.API.Transactions.TransactionDto>($"transactions/{txHash}");
    //        //return await apiProvider.GetTransaction(txHash);
    //    }

    //    public async Task<Transaction> GetTransaction<Transaction>(string txHash)
    //    {
    //        return await apiProvider.GetTransaction<Transaction>(txHash);
    //    }

    //    #endregion

    //    #region usernames

    //    public async Task<Dtos.API.Accounts.AccountDto> GetAccountByUsername(string username)
    //    {
    //        return await apiProvider.GetAccountByUsername(username);
    //    }

    //    #endregion

    //    #region xExchange

    //    public async Task<MexEconomicsDto> GetMexEconomics()
    //    {
    //        return await apiProvider.GetMexEconomics();
    //    }

    //    #endregion

    //    #endregion
    //}
}
