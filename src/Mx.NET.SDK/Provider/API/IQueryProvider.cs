using Mx.NET.SDK.Provider.Dtos.API.Query;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.API
{
    public interface IQueryProvider
    {
        /// <summary>
        /// Query Smart Contract and retrieve the execution results (the Virtual Machine Output) from API.
        /// </summary>
        /// <param name="queryVmRequestDto"></param>
        /// <returns><see cref="QueryResponseDto"/></returns>
        Task<QueryResponseDto> Query(QueryRequestDto queryVmRequestDto);
    }
}
