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

        /// <summary>
        /// Retrieve a value stored under a given account
        /// </summary>
        /// <param name="address">Wallet address in bech32 format</param>
        /// <param name="key">Storage Key</param>
        /// <param name="isHex">Is hexadecimal encoded string</param>
        /// <returns></returns>
        Task<GatewayKeyValueDto> GetStorageValue(string address, string key, bool isHex = false);

        /// <summary>
        /// retrieve all the key-value pairs stored under a given account
        /// </summary>
        /// <param name="address">Wallet address in bech32 format</param>
        /// <returns></returns>
        Task<GatewayKeyValuePairsDto> GetAllStorageValues(string address);
    }
}
