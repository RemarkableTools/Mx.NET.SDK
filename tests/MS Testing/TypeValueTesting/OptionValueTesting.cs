using Mx.NET.SDK.Core.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTesting.TypeValueTesting
{
    [TestClass]
    public class OptionValueTesting : TypeValueBaseTesting
    {
        [TestMethod]
        public async Task Add_Option_U8()
        {
            await InitializeAsync();

            var args = new IBinaryType[]
            {
                OptionValue.NewProvided(NumericValue.U8Value(3))
            };

            await ExecuteAndValidateAddTest(args, "insertOptionU8");
        }

        [TestMethod]
        public async Task Get_Option_U8()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<NumericValue, uint>("getOptionU8");

            Assert.AreEqual(result, (uint)3);
        }

        [TestMethod]
        public async Task Add_Option_Empty_U8()
        {
            await InitializeAsync();

            var args = new IBinaryType[]
            {
                OptionValue.NewMissing()
            };

            await ExecuteAndValidateAddTest(args, "insertOptionEmptyU8");
        }

        [TestMethod]
        public async Task Get_Option_Empty_U8()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<NumericValue, uint>("getOptionEmptyU8");

            Assert.AreEqual(result, (uint)8);
        }

        [TestMethod]
        public async Task Add_OptionalValue_U8()
        {
            await InitializeAsync();

            var args = new IBinaryType[]
            {
                OptionalValue.NewProvided(NumericValue.U8Value(6))
            };

            await ExecuteAndValidateAddTest(args, "insertOptionalValueU8");
        }

        [TestMethod]
        public async Task Get_OptionalValue_U8()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<NumericValue, uint>("getOptionalU8");

            Assert.AreEqual(result, (uint)6);
        }

        [TestMethod]
        public async Task Add_OptionalValue_Empty_U8()
        {
            await InitializeAsync();

            var args = new IBinaryType[]
            {
                OptionalValue.NewMissing()
            };

            await ExecuteAndValidateAddTest(args, "insertOptionalValueEmptyU8");
        }

        [TestMethod]
        public async Task Get_OptionalValue_Empty_U8()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<NumericValue, uint>("getOptionalEmptyU8");

            Assert.AreEqual(result, (uint)12);
        }


        [TestMethod]
        public async Task Get_OptionalValue_Empty_U64()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<OptionalValue, ulong?>("getOptionalValueEmptyU64");

            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public async Task Get_OptionalValue_U64()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<OptionalValue, ulong>("getOptionalValueU64");

            Assert.AreEqual(result, (ulong)698547526);
        }

        [TestMethod]
        public async Task Get_Option_Empty_U64()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<OptionValue, ulong?>("getOptionValueEmptyU64");

            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public async Task Get_Option_U64()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<OptionValue, ulong>("getOptionValueU64");

            Assert.AreEqual(result, (ulong)365214859);
        }
    }
}
