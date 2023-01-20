using System;

namespace Mx.NET.SDK.Domain.Exceptions
{
    public class GatewayException : Exception
    {
        public GatewayException(string message, string code)
            : base($"Error when calling API: {message} with code: {code}") { }
    }
}
