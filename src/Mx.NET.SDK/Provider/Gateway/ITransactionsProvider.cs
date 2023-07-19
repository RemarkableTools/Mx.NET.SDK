using Mx.NET.SDK.Provider.Dtos.Gateway.Transactions;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Gateway
{
    public interface ITransactionsProvider
    {
        /// <summary>
        /// This endpoint allows one to query the details of a Transaction.
        /// </summary>
        /// <param name="txHash">The transaction hash</param>
        /// <returns><see cref="TransactionDto"/></returns>
        Task<TransactionDto> GetTransactionDetail(string txHash);

        /// <summary>
        /// This endpoint allows one to estimate the cost of a transaction.
        /// </summary>
        /// <param name="transactionRequestDto">The transaction payload</param>
        /// <returns><see cref="TransactionCostDataDto"/></returns>
        Task<TransactionCostDto> GetTransactionCost(TransactionRequestDto transactionRequestDto);

        /// <summary>
        /// This endpoint allows one to send a signed Transaction to the Blockchain.
        /// </summary>
        /// <param name="transactionRequest">The transaction payload</param>
        /// <returns>TxHash</returns>
        Task<TransactionResponseDto> SendTransaction(TransactionRequestDto transactionRequest);

        /// <summary>
        /// This endpoint allows one to send multiple signed Transactions to the Blockchain.
        /// </summary>
        /// <param name="transactionsRequest">Array of transactions payload</param>
        /// <returns><see cref="MultipleTransactionsResponseDto"/></returns>
        Task<MultipleTransactionsResponseDto> SendTransactions(TransactionRequestDto[] transactionsRequest);
    }
}
