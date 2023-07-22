﻿using Mx.NET.SDK.Provider.Dtos.Gateway.Query;
using System.Threading.Tasks;

namespace Mx.NET.SDK.Provider.Gateway
{
    public interface IQueryVmProvider
    {
        /// <summary>
        /// This endpoint allows one to execute - with no side-effects - a pure function of a Smart Contract and retrieve the execution results (the Virtual Machine Output).
        /// </summary>
        /// <param name="queryVmRequestDto"></param>
        /// <returns><see cref="QueryVmDto"/></returns>
        Task<QueryVmDto> QueryVm(QueryVmRequestDto queryVmRequestDto);
    }
}
