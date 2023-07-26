using Mx.NET.SDK.Core.Domain.Values;
using System.Numerics;

namespace MSTesting.TypeValueTesting
{
    [TestClass]
    public class SimpleValueTesting : TypeValueBaseTesting
    {

        [TestMethod]
        public async Task Add_U8Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.U8Value(5)
            };

            await ExecuteAndValidateAddTest(args, "insertU8");
        }

        [TestMethod]
        public async Task Get_U8Value()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, uint>("getU8");

            Assert.AreEqual(result, (uint)5);
        }

        [TestMethod]
        public async Task Add_U16Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.U16Value(16)
            };

            await ExecuteAndValidateAddTest(args, "insertU16");
        }

        [TestMethod]
        public async Task Get_U16Value()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, uint>("getU16");

            Assert.AreEqual(result, (uint)16);
        }

        [TestMethod]
        public async Task Add_U32Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.U32Value(32)
            };

            await ExecuteAndValidateAddTest(args, "insertU32");
        }

        [TestMethod]
        public async Task Get_U32Value()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, uint>("getU32");

            Assert.AreEqual(result, (uint)32);
        }

        [TestMethod]
        public async Task Add_U64Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.U64Value(64)
            };

            await ExecuteAndValidateAddTest(args, "insertU64");
        }

        [TestMethod]
        public async Task Get_U64Value()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, ulong>("getU64");

            Assert.AreEqual(result, (ulong)64);
        }

        [TestMethod]
        public async Task Add_BigUIntValue()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.BigUintValue(5555687458961)
            };

            await ExecuteAndValidateAddTest(args, "insertBigUInt");
        }

        [TestMethod]
        public async Task Get_BigUIntValue()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, BigInteger>("getBigUInt");

            Assert.AreEqual(result, new BigInteger(5555687458961));
        }


        [TestMethod]
        public async Task Add_I8Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.I8Value(8)
            };

            await ExecuteAndValidateAddTest(args, "insertI8");
        }

        [TestMethod]
        public async Task Get_I8Value()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, int>("getI8");

            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public async Task Add_I16Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.I16Value(16)
            };

            await ExecuteAndValidateAddTest(args, "insertI16");
        }

        [TestMethod]
        public async Task Get_I16Value()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, int>("getI16");

            Assert.AreEqual(result, 16);
        }

        [TestMethod]
        public async Task Add_I32Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.I32Value(32)
            };

            await ExecuteAndValidateAddTest(args, "insertI32");
        }

        [TestMethod]
        public async Task Get_I32Value()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, int>("getI32");

            Assert.AreEqual(result, 32);
        }

        [TestMethod]
        public async Task Add_I64Value()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.I64Value(64)
            };

            await ExecuteAndValidateAddTest(args, "insertI64");
        }

        [TestMethod]
        public async Task Get_I64Value()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, long>("getI64");

            Assert.AreEqual(result, 64);
        }

        [TestMethod]
        public async Task Add_BigIntValue()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.BigIntValue(5555687458961)
            };

            await ExecuteAndValidateAddTest(args, "insertBigInt");
        }

        [TestMethod]
        public async Task Get_BigIntValue()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, BigInteger>("getBigInt");

            Assert.AreEqual(result, new BigInteger(5555687458961));
        }

        [TestMethod]
        public async Task Add_Address()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                Address.FromBech32("erd13zn08mldnvdpewqtxuhpjupkn33tfxp3x05ve7hvkw7nl3zhuyaqfmk0rc")
            };

            await ExecuteAndValidateAddTest(args, "insertManagedAddress");
        }

        [TestMethod]
        public async Task Get_Address()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<Address, Address>("getManagedAddress");

            Assert.AreEqual(result.Bech32, "erd13zn08mldnvdpewqtxuhpjupkn33tfxp3x05ve7hvkw7nl3zhuyaqfmk0rc");
        }

        [TestMethod]
        public async Task Add_TokenIdentifier()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                ESDTIdentifierValue.From("WEGLD-01e49d")
            };

            await ExecuteAndValidateAddTest(args, "insertTokenIdentifier");
        }

        [TestMethod]
        public async Task Get_TokenIdentifier()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<ESDTIdentifierValue, string>("getTokenIdentifier");


            Assert.AreEqual(result, "WEGLD-01e49d");
        }

        [TestMethod]
        public async Task Add_EgldOrEsdtTokenIdentifier()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                ESDTIdentifierValue.From("WEGLD-01e49d")
            };

            await ExecuteAndValidateAddTest(args, "insertEgldOrEsdtTokenIdentifier");
        }        

        [TestMethod]
        public async Task Get_EgldOrEsdtTokenIdentifier()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<ESDTIdentifierValue, string>("getEgldOrEsdtTokenIdentifier");

            Assert.AreEqual(result, "WEGLD-01e49d");
        }

        
    }
}
