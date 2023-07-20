using Mx.NET.SDK.Core.Domain;
using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Domain.Data.Common;
using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Provider.Dtos.API.Account;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Domain.Data.Account
{
    /// <summary>
    /// Account object for an address
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account address
        /// </summary>
        public Address Address { get; private set; }

        /// <summary>
        /// Account EGLD balance
        /// </summary>
        public ESDTAmount Balance { get; private set; }

        /// <summary>
        /// Account nonce
        /// </summary>
        public ulong Nonce { get; private set; }

        /// <summary>
        /// Account shard
        /// </summary>
        public long Shard { get; private set; }

        /// <summary>
        /// Account assets
        /// </summary>
        public dynamic Assets { get; private set; } //JSON data

        /// <summary>
        /// Account root hash
        /// </summary>
        public string RootHash { get; private set; }

        /// <summary>
        /// The number of transactions of Account
        /// </summary>
        public BigInteger TxCount { get; private set; }

        /// <summary>
        /// The number of transactions with smart contracts of Account
        /// </summary>
        public BigInteger SrcCount { get; private set; }

        /// <summary>
        /// Account user name (herotag)
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Account developer reward
        /// </summary>
        public string DeveloperReward { get; private set; }

        /// <summary>
        /// Account scam info
        /// </summary>
        public ScamInfo ScamInfo { get; private set; }

        /// <summary>
        /// Account is guarded
        /// </summary>
        public bool IsGuarded { get; private set; }

        /// <summary>
        /// Guardian activation epoch
        /// </summary>
        public long ActivationEpoch { get; private set; }

        /// <summary>
        /// Guardian address
        /// </summary>
        public Address Guardian { get; private set; }

        /// <summary>
        /// Guardian Service UID
        /// </summary>
        public string ServiceUID { get; private set; }

        /// <summary>
        /// Pending guardian activation epoch
        /// </summary>
        public long PendingActivationEpoch { get; private set; }

        /// <summary>
        /// Pending guardian address
        /// </summary>
        public Address PendingGuardian { get; private set; }

        /// <summary>
        /// Pending guardian Service UID
        /// </summary>
        public string PendingServiceUID { get; private set; }

        private Account() { }

        public Account(Address address)
        {
            Address = address;
            Nonce = 0;
            Balance = ESDTAmount.Zero();
            UserName = null;
        }

        /// <summary>
        /// Synchronizes account properties with the ones queried from the Network
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public async Task Sync(Provider.API.IAccountsProvider provider)
        {
            var accountDto = await provider.GetAccount(Address.Bech32);

            Balance = ESDTAmount.From(accountDto.Balance, ESDT.EGLD());
            Nonce = accountDto.Nonce;
            Shard = accountDto.Shard;
            Assets = accountDto.Assets;
            if (accountDto.RootHash != null) RootHash = Converter.ToHexString(Convert.FromBase64String(accountDto.RootHash)).ToLower();
            TxCount = accountDto.TxCount;
            SrcCount = accountDto.ScrCount;
            UserName = accountDto.UserName;
            DeveloperReward = accountDto.DeveloperReward;
            ScamInfo = ScamInfo.From(accountDto.ScamInfo);
            IsGuarded = accountDto.IsGuarded ?? false;
            ActivationEpoch = accountDto.ActiveGuardianActivationEpoch ?? 0;
            Guardian = accountDto.ActiveGuardianAddress is null ? null : Address.FromBech32(accountDto.ActiveGuardianAddress);
            ServiceUID = accountDto.ActiveGuardianServiceUid ?? string.Empty;
            PendingActivationEpoch = accountDto.PendingGuardianActivationEpoch ?? 0;
            PendingGuardian = accountDto.PendingGuardianAddress is null ? null : Address.FromBech32(accountDto.PendingGuardianAddress);
            PendingServiceUID = accountDto.PendingGuardianServiceUid ?? string.Empty;
        }
        public async Task Sync(Provider.Gateway.IAddressesProvider provider)
        {
            var accountDto = await provider.GetAddress(Address.Bech32);

            Balance = ESDTAmount.From(accountDto.Balance, ESDT.EGLD());
            Nonce = accountDto.Nonce;
            Address = Address.FromBech32(accountDto.Address);
            UserName = accountDto.Username;
        }

        /// <summary>
        /// Creates a new account object from data
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Account From(AccountDto account)
        {
            return new Account()
            {
                Address = Address.FromBech32(account.Address),
                Balance = ESDTAmount.From(account.Balance, ESDT.EGLD()),
                Nonce = account.Nonce,
                Shard = account.Shard,
                Assets = account.Assets,
                RootHash = account.RootHash is null ? null : Converter.ToHexString(Convert.FromBase64String(account.RootHash)).ToLower(),
                TxCount = account.TxCount,
                SrcCount = account.ScrCount,
                UserName = account.UserName,
                DeveloperReward = account.DeveloperReward,
                ScamInfo = ScamInfo.From(account.ScamInfo),
                IsGuarded = account.IsGuarded ?? false,
                ActivationEpoch = account.ActiveGuardianActivationEpoch ?? 0,
                Guardian = account.ActiveGuardianAddress is null ? null : Address.FromBech32(account.ActiveGuardianAddress),
                ServiceUID = account.ActiveGuardianServiceUid ?? string.Empty,
                PendingActivationEpoch = account.PendingGuardianActivationEpoch ?? 0,
                PendingGuardian = account.PendingGuardianAddress is null ? null : Address.FromBech32(account.PendingGuardianAddress),
                PendingServiceUID = account.PendingGuardianServiceUid ?? string.Empty
            };
        }
        public static Account From(string address)
        {
            return new Account(Address.FromBech32(address));
        }
        /// <summary>
        /// Increments (locally) the nonce (Account sequence number).
        /// </summary>
        public void IncrementNonce()
        {
            Nonce++;
        }
    }
}
