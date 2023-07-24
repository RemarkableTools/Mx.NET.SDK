﻿using Mx.NET.SDK.Provider.API;
using Mx.NET.SDK.Provider.Dtos.API.Network;
using Mx.NET.SDK.Provider.Dtos.Gateway.Network;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Domain.Data.Network
{
    public class NetworkStats
    {
        public int Shards { get; set; }
        public long Blocks { get; set; }
        public long Accounts { get; set; }
        public long Transactions { get; set; }
        public long RefreshRate { get; set; }
        public long Epoch { get; set; }
        public long RoundsPassed { get; set; }
        public long RoundsPerEpoch { get; set; }

        private NetworkStats(NetworkStatsDto stats)
        {
            Shards = stats.Shards;
            Blocks = stats.Blocks;
            Accounts = stats.Accounts;
            Transactions = stats.Transactions;
            RefreshRate = stats.RefreshRate;
            Epoch = stats.Epoch;
            RoundsPassed = stats.RoundsPassed;
            RoundsPerEpoch = stats.RoundsPerEpoch;
        }

        /// <summary>
        /// Get general network statistics From API
        /// </summary>
        /// <param name="provider">Network provider</param>
        /// <returns>NetworkEconomics</returns>
        public static async Task<NetworkStats> GetFromNetwork(INetworkProvider provider)
        {
            return new NetworkStats(await provider.GetNetworkStats());
        }
    }
}
