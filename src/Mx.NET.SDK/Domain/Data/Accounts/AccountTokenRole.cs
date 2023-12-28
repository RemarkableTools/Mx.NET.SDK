﻿using System.Numerics;
using Mx.NET.SDK.Domain.Data.Common;
using Mx.NET.SDK.Domain.Data.Properties;
using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Provider.Dtos.API.Accounts;
using System.Linq;
using Mx.NET.SDK.Core.Domain;

namespace Mx.NET.SDK.Domain.Data.Accounts
{
    /// <summary>
    /// Account Token object with roles
    /// </summary>
    public class AccountTokenRole
    {
        /// <summary>
        /// Token Type
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Token Identifier
        /// </summary>
        public ESDTIdentifierValue Identifier { get; private set; }

        /// <summary>
        /// Token name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Token ticker
        /// </summary>
        public string Ticker { get; private set; }

        /// <summary>
        /// The owner of Token
        /// </summary>
        public Address Owner { get; private set; }

        /// <summary>
        /// The decimal precision
        /// </summary>
        public int Decimals { get; private set; }

        /// <summary>
        /// Token is paused
        /// </summary>
        public bool IsPaused { get; private set; }

        /// <summary>
        /// The assets of Token
        /// </summary>
        public dynamic Assets { get; private set; }

        /// <summary>
        /// The number of transactions for Token
        /// </summary>
        public BigInteger Transactions { get; private set; }

        /// <summary>
        /// The number of accounts that possess some tokens
        /// </summary>
        public BigInteger Accounts { get; private set; }

        /// <summary>
        /// Token properties
        /// </summary>
        public TokenProperties Properties { get; private set; }

        /// <summary>
        /// The account role in Token collection
        /// </summary>
        public TokenAccountRole Role { get; private set; }

        private AccountTokenRole() { }

        /// <summary>
        /// Creates a new AccountTokenRole from data
        /// </summary>
        /// <param name="token">Token Data Object from API</param>
        /// <returns>EsdtToken object</returns>
        public static AccountTokenRole From(AccountTokenRoleDto token)
        {
            return new AccountTokenRole()
            {
                Type = token.Type,
                Identifier = ESDTIdentifierValue.From(token.Identifier),
                Name = token.Name,
                Ticker = token.Ticker ?? token.Identifier.GetTicker(),
                Owner = Address.FromBech32(token.Owner),
                Decimals = token.Decimals,
                IsPaused = token.IsPaused,
                Assets = token.Assets,
                Properties = TokenProperties.From(token.CanFreeze,
                                                  token.CanWipe,
                                                  token.CanPause,
                                                  token.CanUpgrade,
                                                  token.CanChangeOwner,
                                                  token.CanAddSpecialRoles),
                Role = TokenAccountRole.From(token.Role)
            };
        }

        /// <summary>
        /// Creates a new array of AccountTokenRole from data
        /// </summary>
        /// <param name="tokens">Array of Token Data Object from API</param>
        /// <returns>EsdtToken object</returns>
        public static AccountTokenRole[] From(AccountTokenRoleDto[] tokens)
        {
            return tokens.Select(token => new AccountTokenRole()
            {
                Type = token.Type,
                Identifier = ESDTIdentifierValue.From(token.Identifier),
                Name = token.Name,
                Ticker = token.Ticker ?? token.Identifier.GetTicker(),
                Owner = Address.FromBech32(token.Owner),
                Decimals = token.Decimals,
                IsPaused = token.IsPaused,
                Assets = token.Assets,
                Properties = TokenProperties.From(token.CanFreeze,
                                                  token.CanWipe,
                                                  token.CanPause,
                                                  token.CanUpgrade,
                                                  token.CanChangeOwner,
                                                  token.CanAddSpecialRoles),
                Role = TokenAccountRole.From(token.Role)
            }).ToArray();
        }

        /// <summary>
        /// Get the ESDT object from Token
        /// </summary>
        /// <returns></returns>
        public ESDT GetESDT()
        {
            return ESDT.TOKEN(Name, Identifier.Value, Decimals);
        }
    }
}
