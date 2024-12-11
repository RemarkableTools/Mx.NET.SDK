using System.Collections.Generic;
using System.Threading.Tasks;
using Mx.NET.SDK.Provider.Dtos.API.Pool;

namespace Mx.NET.SDK.Provider.API
{
    public interface IPoolProvider
    {
        /// <summary>
        /// Returns an array of pool transactions
        /// </summary>
        /// <param name="size">Number of items to retrieve (max 10000)</param>
        /// <param name="from">Number of items to skip for the result set</param>
        /// <param name="parameters">Parameters for query</param>
        /// <returns><see cref="PoolTransactionDto"/></returns>
        Task<PoolTransactionDto[]> GetPool(int size = 100, int from = 0, Dictionary<string, string> parameters = null);

        /// <summary>
        /// Returns an array of pool transactions
        /// </summary>
        /// <typeparam name="PoolTransaction">Custom DTO</typeparam>
        /// <param name="size">Number of items to retrieve (max 10000)</param>
        /// <param name="from">Number of items to skip for the result set</param>
        /// <param name="parameters">Parameters for query</param>
        /// <returns></returns>
        Task<PoolTransaction[]> GetPool<PoolTransaction>(int size = 100, int from = 0, Dictionary<string, string> parameters = null);

        /// <summary>
        /// Returns the counter of pool transactions
        /// </summary>
        /// <param name="parameters">Parameters for query</param>
        /// <returns></returns>
        Task<string> GetPoolCount(Dictionary<string, string> parameters = null);

        /// <summary>
        /// This endpoint allows one to query the details of a Pool Transaction.
        /// </summary>
        /// <param name="txHash">The pool transaction hash</param>
        /// <returns><see cref="PoolTransactionDto"/></returns>
        Task<PoolTransactionDto> GetPoolTransaction(string txHash);

        /// <summary>
        /// This endpoint allows one to query the details of a Pool Transaction.
        /// </summary>
        /// <param name="txHash">The pool transaction hash</param>
        /// <returns>Your custom Pool Transaction object</returns>
        Task<PoolTransaction> GetPoolTransaction<PoolTransaction>(string txHash);
    }
}
