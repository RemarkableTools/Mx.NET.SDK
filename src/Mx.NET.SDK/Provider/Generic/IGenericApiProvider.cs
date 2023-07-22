using Mx.NET.SDK.Provider.Dtos.API.Account;
using Mx.NET.SDK.Provider.Dtos.API.Transactions;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Generic
{
    public interface IGenericApiProvider
    {
        /// <summary>
        /// Returns account details for a given address
        /// </summary>
        /// <param name="address">Wallet address in bech32 format</param>
        /// <returns><see cref="AccountDto"/></returns>
        Task<AccountDto> GetAccount(string address);

        /// <summary>
        /// This endpoint allows one to query the details of a Transaction.
        /// </summary>
        /// <param name="txHash">The transaction hash</param>
        /// <returns><see cref="TransactionDto"/></returns>
        Task<TransactionDto> GetTransaction(string txHash);
    }
}
