using Mx.NET.SDK.Provider.Dtos.Gateway.Blocks;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Gateway
{
    public interface IBlocksProvider
    {
        /// <summary>
        /// This endpoint allows one to query a Shard Block by its nonce (or height).
        /// </summary>
        /// <returns><see cref="Block"/></returns>
        Task<BlockDto> GetBlockNonce(long nonce, long shard, bool withTxs = false);

        /// <summary>
        /// This endpoint allows one to query a Shard Block by its hash.
        /// </summary>
        /// <returns><see cref="Block"/></returns>
        Task<BlockDto> GetBlockHash(string hash, long shard, bool withTxs = false);

        Task<InternalBlockDto> GetInternalBlockNonce(long nonce);
        Task<InternalBlockDto> GetInternalBlockHash(string hash);

    }
}
