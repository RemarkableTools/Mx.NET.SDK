using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Core.Domain.Values;

namespace MSTesting.TypeValueTesting
{
    [TestClass]
    public class TupleValueTesting : TypeValueBaseTesting
    {
        [TestMethod]
        public async Task Add_Tuple_I64Value_BooleanValue()
        {
            await InitializeAsync();

            var args = new IBinaryType[]
            {
                TupleValue.From(new IBinaryType[] { NumericValue.I64Value(967745699814), BooleanValue.From(true)} )
            };

            await ExecuteAndValidateAddTest(args, "insertTupleI64ValueBooleanValue");
        }

        [TestMethod]
        public async Task Get_Tuple_I64Value_BooleanValue()
        {
            await InitializeAsync();

            var (LongValue, BoolValue) = await GetValueForSmartContract<TupleValue, (long LongValue, bool BoolValue)>("getTupleI64ValueBooleanValue");

            Assert.AreEqual(LongValue, 967745699814);
            Assert.AreEqual(BoolValue, true);
        }

        [TestMethod]
        public async Task Add_Tuple_I64Value_BooleanValue_ManagedBuffer()
        {
            await InitializeAsync();

            var args = new IBinaryType[]
            {
                TupleValue.From(new IBinaryType[] { NumericValue.I64Value(967745699814), BooleanValue.From(true), BytesValue.FromUtf8("TupleTest")} )
            };

            await ExecuteAndValidateAddTest(args, "insertTupleI64ValueBooleanValueManagedBuffer");
        }

        [TestMethod]
        public async Task Get_Tuple_I64Value_BooleanValue_ManagedBuffer()
        {
            await InitializeAsync();

            var (LongValue, BoolValue, Name) = await GetValueForSmartContract<TupleValue, (long LongValue, bool BoolValue, string Name)>("getTupleI64ValueBooleanValueManagedBuffer");

            Assert.AreEqual(LongValue, 967745699814);
            Assert.AreEqual(BoolValue, true);
            Assert.AreEqual(Converter.HexToString(Name), "TupleTest");
        }

        [TestMethod]
        public async Task Add_Tuple_ManagedVec_I64_BooleanValue()
        {
            await InitializeAsync();

            var managedVec = ListValue.From(TypeValue.I64TypeValue, new IBinaryType[] { NumericValue.I64Value(58748965247569), NumericValue.I64Value(5476225889951) });
            var args = new IBinaryType[]
            {
                TupleValue.From(new IBinaryType[] { managedVec, BooleanValue.From(true)} )
            };

            await ExecuteAndValidateAddTest(args, "insertTupleManagedVecI64BooleanValue");
        }

        [TestMethod]
        public async Task Get_Tuple_ManagedVec_I64_BooleanValue()
        {
            await InitializeAsync();

            var (LongValues, BoolValue) = await GetValueForSmartContract<TupleValue, (List<long> LongValues, bool BoolValue)>("getTupleManagedVecI64BooleanValue");

            Assert.AreEqual(LongValues.Count, 2);
            Assert.AreEqual(LongValues[0], 58748965247569);
            Assert.AreEqual(LongValues[1], 5476225889951);
            Assert.AreEqual(BoolValue, true);
        }
    }
}
