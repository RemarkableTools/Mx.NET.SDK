using Mx.NET.SDK.Core.Domain.Helper;
using System.Collections.Generic;
using System.Linq;

namespace Mx.NET.SDK.Provider.Dtos.Gateway.Addresses
{
    public class GatewayKeyValuePairsDto
    {
        public GatewayKeyValuePairsDto(Dictionary<string, string> pairs)
        {
            Pairs = pairs.ToDictionary(
                kvp => Converter.HexToString(kvp.Key),
                kvp => Converter.HexToString(kvp.Value));
        }

        public Dictionary<string, string> Pairs { get; set; }
    }
}
