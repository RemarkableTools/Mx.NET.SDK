using Moq;
using Mx.NET.SDK.Core.Domain.Abi;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Domain.SmartContracts;
using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Provider.Dtos.Gateway.Query;

namespace MSTesting
{
    [TestClass]
    public class TypeValueTesting
    {
        private readonly Mock<IMultiversxProvider> provider;

        public TypeValueTesting()
        {
            provider = new Mock<IMultiversxProvider>();
        }

        private void MockQueryResultWithArray(string[] returnData)
        {
            var queryResponse = new QueryVmResponseDto
            {
                Data = new QueryVmResponseDataDto
                {
                    ReturnData = returnData
                }
            };

            provider.Setup(s => s.QueryVm(It.IsAny<QueryVmRequestDto>())).ReturnsAsync(queryResponse);
        }
    }
}
