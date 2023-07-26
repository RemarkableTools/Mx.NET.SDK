using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Core.Domain.Values;

namespace MSTesting.TypeValueTesting
{
    [TestClass]
    public class ListValueTesting : TypeValueBaseTesting
    {
        [TestMethod]
        public async Task Add_ManagedVec_ManagedBuffer()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                ListValue.From(TypeValue.BytesValue, new IBinaryType[] { BytesValue.FromUtf8("OneTest"), BytesValue.FromUtf8("TwoTest") })
            };

            await ExecuteAndValidateAddTest(args, "insertManagedVecManagedBuffer");
        }

        [TestMethod]
        public async Task Get_ManagedVec_ManagedBuffer()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<ListValue, List<string>>("getManagedVecManagedBuffer");

            var convertedResult = result.Select(x => Converter.HexToString(x.ToString())).ToList();

            Assert.AreEqual(convertedResult.Count, 2);
            Assert.AreEqual(convertedResult[0], "OneTest");
            Assert.AreEqual(convertedResult[1], "TwoTest");
        }

        [TestMethod]
        public async Task Add_ManagedVec_I64Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                ListValue.From(TypeValue.I64TypeValue, new IBinaryType[] { NumericValue.I64Value(58748965247569), NumericValue.I64Value(5476225889951) })
            };

            await ExecuteAndValidateAddTest(args, "insertManagedVecI64");
        }

        [TestMethod]
        public async Task Get_ManagedVec_I64Value()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<ListValue, List<long>>("getManagedVecI64");

            Assert.AreEqual(result.Count, 2);
        }
    }
}
