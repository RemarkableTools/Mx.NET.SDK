using Mx.NET.SDK.Provider.Dtos.Gateway.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Dtos.Gateway.Blocks
{
    /// <summary>
    /// Gateway block response
    /// </summary>
    public class BlockResponseDto
    {
        public BlockDto Block { get; set; } = null!;
    }
    /// <summary>
    /// Block
    /// </summary>
    public class BlockDto
    {
        public long Nonce { get; set; }
        public long Round { get; set; }
        public string Hash { get; set; } = null!;
        public string PrevBlockHash { get; set; } = null!;
        public long Epoch { get; set; }
        public long Shard { get; set; }
        public long NumTxs { get; set; }
        public MiniBlockDto[] MiniBlocks { get; set; } = null!;
    }  /// <summary>
       /// Block
       /// </summary>
       /// <summary>
       /// Gateway block response
       /// </summary>
    public class InternalBlockResponseDto
    {
        public InternalBlockDto Block { get; set; } = null!;
    }
    public class InternalBlockDto
    {
        public InternalBlockHeaderDto Header { get; set; } = null!;
        public long ScheduledAccumulatedFees { get; set; }
        public long ScheduledDeveloperFees { get; set; }
        public string ScheduledRootHash { get; set; }
    }
    public class InternalBlockHeaderDto
    {
        public long Nonce { get; set; }
        public long Round { get; set; }
        public string RandSeed { get; set; } = null!;
        public string PrevRandSeed { get; set; } = null!;
        public string PrevHash { get; set; } = null!;
        public long Epoch { get; set; }
        public long ShardID { get; set; }

    }
    public class MiniBlockDto
    {
        public string Hash { get; set; } = null!;
        public string Type { get; set; } = null!;
        public long SourceShard { get; set; }
        public long DestinationShard { get; set; }
        public TransactionDto[] Transactions { get; set; } = null!;
    }
}
