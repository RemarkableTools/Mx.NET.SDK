using Mx.NET.SDK.Domain.Data.Common;
using Mx.NET.SDK.Provider.Dtos.Gateway.Address;

namespace Mx.NET.SDK.Domain.Data.Account
{
    public class AccountGuardianData
    {
        public BlockInfo BlockInfo { get; set; }
        public GuardianData GuardianData { get; set; }

        private AccountGuardianData() { }

        public static AccountGuardianData From(GatewayAddressGuardianDataDto guardianData)
        {
            return new AccountGuardianData()
            {
                BlockInfo = BlockInfo.From(guardianData.Data.BlockInfo),
                GuardianData = GuardianData.From(guardianData.Data.GuardianData)
            };
        }
    }
}
