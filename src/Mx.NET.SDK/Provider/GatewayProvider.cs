using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Domain.Exceptions;
using Mx.NET.SDK.Provider.Dtos.Gateway;
using Mx.NET.SDK.Provider.Dtos.Gateway.Addresses;
using Mx.NET.SDK.Provider.Dtos.Gateway.Blocks;
using Mx.NET.SDK.Provider.Dtos.Gateway.ESDTs;
using Mx.NET.SDK.Provider.Dtos.Gateway.Network;
using Mx.NET.SDK.Provider.Dtos.Gateway.Query;
using Mx.NET.SDK.Provider.Dtos.Gateway.Transactions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider
{
    public class GatewayProvider : IGatewayProvider
    {
        private readonly HttpClient _httpGatewayClient;
        public readonly MultiversxNetworkConfiguration NetworkConfiguration;

        public GatewayProvider(MultiversxNetworkConfiguration configuration)
        {
            NetworkConfiguration = configuration;

            _httpGatewayClient = new HttpClient
            {
                BaseAddress = configuration.GatewayUri
            };
        }

        #region generic
        public async Task<TR> GetGW<TR>(string requestUri)
        {
            var uri = requestUri.StartsWith("/") ? requestUri.Substring(1) : requestUri;
            var response = await _httpGatewayClient.GetAsync($"{uri}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new APIException(content);

            var result = JsonWrapper.Deserialize<GatewayResponseDto<TR>>(content);
            result.EnsureSuccessStatusCode();
            return result.Data;
        }

        public async Task<TR> PostGW<TR>(string requestUri, object requestContent)
        {
            var uri = requestUri.StartsWith("/") ? requestUri.Substring(1) : requestUri;
            var raw = JsonWrapper.Serialize(requestContent);
            var payload = new StringContent(raw, Encoding.UTF8, "application/json");
            var response = await _httpGatewayClient.PostAsync(uri, payload);

            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new APIException(content);

            var result = JsonWrapper.Deserialize<GatewayResponseDto<TR>>(content);
            result.EnsureSuccessStatusCode();
            return result.Data;
        }
        public async Task<QueryVmResponseDto> QueryVm(QueryVmRequestDto queryVmRequestDto)
        {
            return await PostGW<QueryVmResponseDto>("vm-values/query", queryVmRequestDto);
        }
        #endregion

        public async Task<AccountDto> GetAddress(string address)
        {
            return await GetGW<AccountDto>($"address/{address}");
        }
        public async Task<GatewayAddressGuardianDataDto> GetAccountGuardianData(string address)
        {
            return await GetGW<GatewayAddressGuardianDataDto>($"address/{address}/guardian-data");
        }
        public async Task<GatewayKeyValueDto> GetStorageValue(string address, string key, bool isHex = false)
        {
            if (!isHex) key = Converter.ToHexString(key);

            return await GetGW<GatewayKeyValueDto>($"address/{address}/key/{key}");
        }
        public async Task<GatewayKeyValuePairsDto> GetAllStorageValues(string address)
        {
            return await GetGW<GatewayKeyValuePairsDto>($"address/{address}/keys");
        }

        public async Task<NetworkConfigDataDto> GetNetworkConfig()
        {
            return await GetGW<NetworkConfigDataDto>("network/config");
        }
        public async Task<NetworkEconomicsDataDto> GetNetworkEconomics()
        {
            return await GetGW<NetworkEconomicsDataDto>("network/economics");
        }
        public async Task<ShardStatusDto> GetShardStatus(long? shard = null)
        {
            return await GetGW<ShardStatusDto>($"network/status/{shard}");
        }

        public async Task<EsdtTokenDataDto> GetEsdtTokens(string address)
        {
            return await GetGW<EsdtTokenDataDto>($"address/{address}/esdt");
        }
        public async Task<EsdtTokenData> GetEsdtToken(string address, string tokenIdentifier)
        {
            return await GetGW<EsdtTokenData>($"address/{address}/esdt/{tokenIdentifier}");
        }

        public async Task<BlockDto> GetBlockNonce(long nonce, long shard, bool withTxs = false)
        {
            return await GetGW<BlockDto>($"/block/by-nonce/{nonce}?withTxs={withTxs}&withResults=true");
        }
        public async Task<BlockDto> GetBlockHash(string hash, long shard, bool withTxs = false)
        {
            return await GetGW<BlockDto>($"/block/{shard}/by-hash/{hash}?withTxs={withTxs}");
        }
        public async Task<InternalBlockDto> GetInternalBlockNonce(long nonce)
        {
            return await GetGW<InternalBlockDto>($"/internal/json/shardblock/by-nonce/{nonce}");
        }
        public async Task<InternalBlockDto> GetInternalBlockHash(string hash)
        {
            return await GetGW<InternalBlockDto>($"/internal/json/shardblock/by-hash/{hash}");
        }

        public async Task<TransactionDto> GetTransactionDetail(string txHash)
        {
            return await GetGW<TransactionDto>($"transaction/{txHash}?withResults=true");
        }
        public async Task<TransactionCostDto> GetTransactionCost(TransactionRequestDto transactionRequestDto)
        {
            return await PostGW<TransactionCostDto>("transaction/cost", transactionRequestDto);
        }
        public async Task<TransactionResponseDto> SendTransaction(TransactionRequestDto transactionRequest)
        {
            return await PostGW<TransactionResponseDto>("transaction/send", transactionRequest);
        }
        public async Task<MultipleTransactionsResponseDto> SendTransactions(TransactionRequestDto[] transactionsRequest)
        {
            return await PostGW<MultipleTransactionsResponseDto>("transaction/send-multiple", transactionsRequest);
        }
    }
}