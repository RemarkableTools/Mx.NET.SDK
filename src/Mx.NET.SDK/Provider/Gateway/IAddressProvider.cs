using Mx.NET.SDK.Provider.Dtos.Gateway.Address;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Gateway
{
    public interface IAddressProvider
    {
        /// <summary>
        /// Returns the guardian data for an address
        /// </summary>
        /// <param name="address">Wallet address in bech32 format</param>
        /// <returns><see cref="GatewayAddressGuardianDataDto"/></returns>
        Task<GatewayAddressGuardianDataDto> GetAccountGuardianData(string address);
    }
}
