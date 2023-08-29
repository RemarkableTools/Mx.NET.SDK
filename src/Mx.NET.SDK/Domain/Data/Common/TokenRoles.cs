using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Provider.Dtos.API.Common;
using System.Linq;

namespace Mx.NET.SDK.Domain.Data.Common
{
    /// <summary>
    /// /tokens/{identifier} endpoint
    /// </summary>
    public class TokenRoles
    {
        public bool CanLocalMint { get; private set; }
        public bool CanLocalBurn { get; private set; }
        public string[] Roles { get; private set; }
        public Address Address { get; private set; }

        private TokenRoles() { }

        public static TokenRoles[] From(TokenRolesDto[] roles)
        {
            if (roles == null) return null;

            return roles.Select(role => new TokenRoles()
            {
                CanLocalMint = role.CanLocalMint,
                CanLocalBurn = role.CanLocalBurn,
                Roles = role.Roles,
                Address = Address.FromBech32(role.Address)
            }).ToArray();
        }
    }
}
