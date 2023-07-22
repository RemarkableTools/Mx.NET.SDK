using Mx.NET.SDK.Provider.Dtos.Gateway.Network;
using Mx.NET.SDK.Provider.Dtos.Gateway.Query;
using Mx.NET.SDK.Provider.Dtos.Gateway.Transactions;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Generic
{
    public interface IGenericGatewayProvider
    {
        /// <summary>
        /// This endpoint allows one to query basic details about the configuration of the Network.
        /// </summary>
        /// <returns><see cref="NetworkConfigDataDto"/></returns>
        Task<NetworkConfigDataDto> GetNetworkConfig();

        /// <summary>
        /// This endpoint allows one to execute - with no side-effects - a pure function of a Smart Contract and retrieve the execution results (the Virtual Machine Output).
        /// </summary>
        /// <param name="queryVmRequestDto"></param>
        /// <returns><see cref="QueryVmDto"/></returns>
        Task<QueryVmDto> QueryVm(QueryVmRequestDto queryVmRequestDto);

        /// <summary>
        /// This endpoint allows one to send a signed Transaction to the Blockchain.
        /// </summary>
        /// <param name="transactionRequest">The transaction payload</param>
        /// <returns>TxHash</returns>
        Task<TransactionResponseDto> SendTransaction(TransactionRequestDto transactionRequest);

        /// <summary>
        /// This endpoint allows one to send a bulk of Transactions to the Blockchain.
        /// </summary>
        /// <param name="transactionsRequest">Array of transactions payload</param>
        /// <returns><see cref="MultipleTransactionsResponseDto"/></returns>
        Task<MultipleTransactionsResponseDto> SendTransactions(TransactionRequestDto[] transactionsRequest);
    }
}
