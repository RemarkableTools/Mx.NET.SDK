using Mx.NET.SDK.Domain.Data.Properties;
using Mx.NET.SDK.Provider.Dtos.API.Common;

namespace Mx.NET.SDK.Domain.Data.Common
{
    /// <summary>
    /// /accounts/{address}/roles/tokens endpoint
    /// </summary>
    public class TokenAccountRole
    {
        public bool CanLocalMint { get; private set; }
        public bool CanLocalBurn { get; private set; }
        public string[] Roles { get; private set; }

        private TokenAccountRole() { }

        public static TokenAccountRole From(TokenAccountRoleDto role)
        {
            if (role == null) return null;

            return new TokenAccountRole()
            {
                CanLocalMint = role.CanLocalMint,
                CanLocalBurn = role.CanLocalBurn,
                Roles = role.Roles
            };
        }
    }
}
