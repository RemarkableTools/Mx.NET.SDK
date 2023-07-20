﻿using Mx.NET.SDK.Core.Domain.Helper;

namespace Mx.NET.SDK.Provider.Dtos.Gateway.Addresses
{
    public class GatewayKeyValueDto
    {
        public GatewayKeyValueDto(string value)
        {
            Value = Converter.HexToString(value);
        }

        public string Value { get; set; }
    }
}