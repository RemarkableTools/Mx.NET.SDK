
using Mx.NET.SDK.Provider.Dtos.Gateway.Addresses;
using Mx.NET.SDK.Provider.Dtos.Gateway.Blocks;
using Mx.NET.SDK.Provider.Dtos.Gateway.ESDTs;
using Mx.NET.SDK.Provider.Dtos.Gateway.Network;
using Mx.NET.SDK.Provider.Dtos.Gateway.Query;
using Mx.NET.SDK.Provider.Dtos.Gateway.Transactions;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Gateway
{
    public interface IGenericProvider
    {
        /// <summary>
        /// Generic GET request to Gateway
        /// </summary>
        /// <typeparam name="TR">Custom return object</typeparam>
        /// <param name="requestUri">Request endpoint (e.g. '/economics?extract=price')</param>
        /// <returns></returns>
        Task<TR> GetGW<TR>(string requestUri);

        /// <summary>
        /// Generic POST request to Gateway
        /// </summary>
        /// <typeparam name="TR">Custom return object</typeparam>
        /// <param name="requestUri">Request endpoint (e.g. '/transactions')</param>
        /// <param name="requestContent">Request content object (e.g. TransactionRequestDto object)</param>
        /// <returns></returns>
        Task<TR> PostGW<TR>(string requestUri, object requestContent);
    }
}
