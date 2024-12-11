using System.Linq;
using Mx.NET.SDK.Core.Domain;
using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Provider.Dtos.API.Pool;

namespace Mx.NET.SDK.Domain.Data.Pool
{
    public class PoolTransaction
    {
        /// <summary>
        /// Transaction hash
        /// </summary>
        public string TxHash { get; private set; }

        /// <summary>
        /// Sender address
        /// </summary>
        public Address Sender { get; private set; }

        /// <summary>
        /// Receiver address
        /// </summary>
        public Address Receiver { get; private set; }

        /// <summary>
        /// Receiver Username
        /// </summary>
        public string ReceiverUsername { get; private set; }

        /// <summary>
        /// Guardian
        /// </summary>
        public string Guardian { get; private set; }

        /// <summary>
        /// Guardian Siganture
        /// </summary>
        public string GuardianSignature { get; private set; }

        /// <summary>
        /// Sender nonce
        /// </summary>
        public ulong Nonce { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public ESDTAmount Value { get; private set; }

        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// Network gas price
        /// </summary>
        public long GasPrice { get; private set; }

        /// <summary>
        /// Transaction gas limit
        /// </summary>
        public GasLimit GasLimit { get; private set; }

        /// <summary>
        /// Sender shard
        /// </summary>
        public uint SenderShard { get; private set; }

        /// <summary>
        /// Receiver shard
        /// </summary>
        public uint ReceiverShard { get; private set; }

        /// <summary>
        /// Signature
        /// </summary>
        public string Signature { get; private set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; private set; }

        private PoolTransaction() { }

        /// <summary>
        /// Creates a new Pool Transaction from data
        /// </summary>
        /// <param name="poolTransaction">Pool Transaction Data Object from API</param>
        /// <returns>Pool Transaction object</returns>
        public static PoolTransaction From(PoolTransactionDto poolTransaction)
        {
            return new PoolTransaction()
            {
                TxHash = poolTransaction.TxHash,
                Sender = Address.FromBech32(poolTransaction.Sender),
                Receiver = Address.FromBech32(poolTransaction.Receiver),
                ReceiverUsername = poolTransaction.ReceiverUsername,
                Guardian = poolTransaction.Guardian,
                GuardianSignature = poolTransaction.GuardianSignature,
                Nonce = poolTransaction.Nonce,
                Value = ESDTAmount.From(poolTransaction.Value),
                Data = DataCoder.DecodeData(poolTransaction.Data),
                GasPrice = poolTransaction.GasPrice,
                GasLimit = new GasLimit(poolTransaction.GasLimit),
                SenderShard = poolTransaction.SenderShard,
                ReceiverShard = poolTransaction.ReceiverShard,
                Signature = poolTransaction.Signature,
                Type = poolTransaction.Type,
            };
        }

        /// <summary>
        /// Creates a new array of Pool Transactions from data
        /// </summary>
        /// <param name="poolTransactions">Array of Pool Transaction Data Objects from API</param>
        /// <returns>Array of Pool Transaction objects</returns>
        public static PoolTransaction[] From(PoolTransactionDto[] poolTransactions)
        {
            return poolTransactions.Select(poolTransaction => new PoolTransaction()
            {
                TxHash = poolTransaction.TxHash,
                Sender = Address.FromBech32(poolTransaction.Sender),
                Receiver = Address.FromBech32(poolTransaction.Receiver),
                ReceiverUsername = poolTransaction.ReceiverUsername,
                Guardian = poolTransaction.Guardian,
                GuardianSignature = poolTransaction.GuardianSignature,
                Nonce = poolTransaction.Nonce,
                Value = ESDTAmount.From(poolTransaction.Value),
                Data = DataCoder.DecodeData(poolTransaction.Data),
                GasPrice = poolTransaction.GasPrice,
                GasLimit = new GasLimit(poolTransaction.GasLimit),
                SenderShard = poolTransaction.SenderShard,
                ReceiverShard = poolTransaction.ReceiverShard,
                Signature = poolTransaction.Signature,
                Type = poolTransaction.Type,
            }).ToArray();
        }
    }
}
