namespace Mx.NET.SDK.Provider.Generic
{
    public interface IProvider :
        API.IGenericProvider,
        IGenericApiProvider,
        Gateway.IGenericProvider,
        IGenericGatewayProvider
    { }
}
