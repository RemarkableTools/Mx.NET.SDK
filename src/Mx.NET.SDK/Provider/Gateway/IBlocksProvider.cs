﻿using Mx.NET.SDK.Provider.Dtos.Gateway.Blocks;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Gateway
{
    public interface IBlocksProvider
    {
        /// <summary>
        /// This endpoint allows one to query a Shard Block by its nonce (or height).
        /// </summary>
        /// <returns><see cref="BlockDto"/></returns>
        Task<BlockDto> GetBlockByNonce(ulong nonce, uint shard, bool withTxs = false);

        /// <summary>
        /// This endpoint allows one to query a Shard Block by its hash.
        /// </summary>
        /// <returns><see cref="BlockDto"/></returns>
        Task<BlockDto> GetBlockByHash(string hash, uint shard, bool withTxs = false);

        Task<InternalBlockDto> GetInternalBlockByNonce(ulong nonce);
        Task<InternalBlockDto> GetInternalBlockByHash(string hash);

    }
}
