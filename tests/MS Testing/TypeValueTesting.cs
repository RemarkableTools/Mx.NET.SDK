using MSTesting.Models;
using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Core.Domain;
using Mx.NET.SDK.Core.Domain.Abi;
using Mx.NET.SDK.Core.Domain.SmartContracts;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Domain;
using Mx.NET.SDK.Domain.Data.Account;
using Mx.NET.SDK.Domain.Data.Network;
using Mx.NET.SDK.Domain.Data.Transaction;
using Mx.NET.SDK.Domain.SmartContracts;
using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Provider.Gateway;
using Mx.NET.SDK.TransactionsManager;
using Mx.NET.SDK.Wallet;
using Mx.NET.SDK.Wallet.Wallet;
using System.Diagnostics;
using System.Numerics;
using FieldDefinition = Mx.NET.SDK.Core.Domain.Values.FieldDefinition;

namespace MSTesting
{
    [TestClass]
    public class TypeValueTesting
    {

        private static Wallet _wallet;
        private static IGatewayProvider _gatewayProvider;
        private static IMultiversxProvider _provider;
        private static Address? _scAddress;
        private static WalletSigner _walletSigner;
        private static AbiDefinition _abi;
        private static NetworkConfig? _networkConfig;
        private static Account _account;
        private static bool _isInitialized;

        public TypeValueTesting()
        {

        }

        [TestMethod]
        public async Task Add_U8Value_In_U8Storage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.U8Value(8)
            };

            await ExecuteAndValidateAddTest(args, "insert_u8");
        }

        [TestMethod]
        public async Task Add_U16Value_In_U16Storage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.U16Value(16)
            };

            await ExecuteAndValidateAddTest(args, "insert_u16");
        }

        [TestMethod]
        public async Task Add_U32Value_In_U32Storage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.U32Value(32)
            };

            await ExecuteAndValidateAddTest(args, "insert_u32");
        }

        [TestMethod]
        public async Task Add_U64Value_In_U64Storage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.U64Value(64)
            };

            await ExecuteAndValidateAddTest(args, "insert_u64");
        }

        [TestMethod]
        public async Task Add_BigUIntValue_In_BigUIntStorage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.BigUintValue(5555687458961)
            };

            await ExecuteAndValidateAddTest(args, "insert_big_uint");
        }


        [TestMethod]
        public async Task Add_I8Value_In_I8Storage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.I8Value(8)
            };

            await ExecuteAndValidateAddTest(args, "insert_i8");
        }

        [TestMethod]
        public async Task Add_I16Value_In_I16Storage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.I16Value(16)
            };

            await ExecuteAndValidateAddTest(args, "insert_i16");
        }

        [TestMethod]
        public async Task Add_I32Value_In_I32Storage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.I32Value(32)
            };

            await ExecuteAndValidateAddTest(args, "insert_i32");
        }

        [TestMethod]
        public async Task Add_I64Value_In_I64Storage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.I64Value(64)
            };

            await ExecuteAndValidateAddTest(args, "insert_i64");
        }

        [TestMethod]
        public async Task Add_BigIntValue_In_BigIntStorage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                NumericValue.BigIntValue(5555687458961)
            };

            await ExecuteAndValidateAddTest(args, "insert_big_int");
        }

        [TestMethod]
        public async Task Add_Adress_In_AddressStorage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                Address.FromBech32("erd13zn08mldnvdpewqtxuhpjupkn33tfxp3x05ve7hvkw7nl3zhuyaqfmk0rc")
            };

            await ExecuteAndValidateAddTest(args, "insert_address");
        }

        [TestMethod]
        public async Task Add_EgldIdentifierValue_In_TokenIdentifier_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                ESDTIdentifierValue.From("WEGLD-01e49d")
            };

            await ExecuteAndValidateAddTest(args, "insert_token_identifier");
        }

        [TestMethod]
        public async Task Add_EgldIdentifierValue_In_EgldOrEsdtTokenIdentifier_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                ESDTIdentifierValue.From("WEGLD-01e49d")
            };

            await ExecuteAndValidateAddTest(args, "insert_egld_or_esdt_token_identifier");
        }

        //[TestMethod]
        //public async Task Add_List_Bytes_In_ManagedVe_ManagedBuffer_Should_Success()
        //{

        //    await InitializeAsync();

        //    var args = new IBinaryType[]
        //    {
        //        new ListValue(TypeValue.ListValue(TypeValue.BytesValue), TypeValue.BytesValue, new IBinaryType[] { BytesValue.FromUtf8("test"), BytesValue.FromUtf8("2test") })
        //    };

        //    await ExecuteAndValidateAddTest(args, "insert_managed_vec_managed_buffer");
        //}

        [TestMethod]
        public async Task Add_MyStruct_In_MyStructStorage_Should_Success()
        {
            await InitializeAsync();

            var fieldDefinition = new FieldDefinition[2]
            {
                new FieldDefinition("name", "", TypeValue.BytesValue),
                new FieldDefinition("long_value", "", TypeValue.U64TypeValue),
            };

            var fields = new StructField[2]
            {
                new StructField("name", BytesValue.FromUtf8("test")),
                new StructField("long_value", NumericValue.U64Value(522))

            };

            var args = new IBinaryType[]
            {
                new StructValue(TypeValue.StructValue("TestStruct", fieldDefinition), fields)
            };

            await ExecuteAndValidateAddTest(args, "insert_my_struct");
        }

        [TestMethod]
        public async Task Add_Adress_In_SetMapperAddressStorage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                Address.FromBech32("erd1l6h0hrxskv0kuyz67fcfeyj2ckwfjsc8c9tqyc2k93hcgrdll5qqzk6ej4")
            };

            await ExecuteAndValidateAddTest(args, "insert_set_mapper_address");
        }

        [TestMethod]
        public async Task Add_Adress_In_MapMapper_IdentifierAddressStorage_Should_Success()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                ESDTIdentifierValue.From("WEGLD-01e49d"),
                Address.FromBech32("erd13zn08mldnvdpewqtxuhpjupkn33tfxp3x05ve7hvkw7nl3zhuyaqfmk0rc")
            };

            await ExecuteAndValidateAddTest(args, "insert_map_mapper_token_identifier_address");
        }


        #region Get

        [TestMethod]
        public async Task Get_Variadic_In_MapMapperTokenIdentifierAddressStorage_Should_Success()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<VariadicValue, List<MultiValue>>("StorageMapMapperTokenIdentifierAddress");

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public async Task Get_Variadic_In_SetMapperAddressStorage_Should_Success()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<VariadicValue, List<Address>>("StorageSetMapperAddress");

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public async Task Get_MyScrut_In_MyStructStorage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<StructValue, MyStruct>("storageMyStruct");


            Assert.AreEqual(result.Name, "test");
            Assert.AreEqual(result.LongValue, 522);
        }

        [TestMethod]
        public async Task Get_String_In_TokenIdentifierStorage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<ESDTIdentifierValue, string>("storageTokenIdentifier");


            Assert.AreEqual(result, "WEGLD-01e49d");
        }

        [TestMethod]
        public async Task Get_String_In_EgldOrEsdtTokenIdentifierStorage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<ESDTIdentifierValue, string>("storageEgldOrEsdtTokenIdentifier");

            Assert.AreEqual(result, "WEGLD-01e49d");
        }

        [TestMethod]
        public async Task Get_Address_In_AddressStorage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<Address, Address>("storageAddress");

            Assert.AreEqual(result.Bech32, "erd13zn08mldnvdpewqtxuhpjupkn33tfxp3x05ve7hvkw7nl3zhuyaqfmk0rc");
        }

        [TestMethod]
        public async Task Get_Uint_In_U8Storage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, uint>("storageU8");

            Assert.AreEqual(result, (uint)8);
        }

        [TestMethod]
        public async Task Get_Uint_In_U16Storage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, uint>("storageU16");

            Assert.AreEqual(result, (uint)16);
        }

        [TestMethod]
        public async Task Get_Uint_In_U32Storage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, uint>("storageU32");

            Assert.AreEqual(result, (uint)32);
        }

        [TestMethod]
        public async Task Get_Uint_In_U64Storage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, ulong>("storageU64");

            Assert.AreEqual(result, (ulong)64);
        }

        [TestMethod]
        public async Task Get_BigInteger_In_BigUIntStorage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, BigInteger>("storageBigUint");

            Assert.AreEqual(result, new BigInteger(5555687458961));
        }

        [TestMethod]
        public async Task Get_Int_In_I8Storage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, int>("storageI8");

            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public async Task Get_Int_In_I16Storage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, int>("storageI16");

            Assert.AreEqual(result, 16);
        }

        [TestMethod]
        public async Task Get_Int_In_I32Storage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, int>("storageI32");

            Assert.AreEqual(result, 32);
        }

        [TestMethod]
        public async Task Get_Int_In_I64Storage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, long>("storageI64");

            Assert.AreEqual(result, (long)64);
        }

        [TestMethod]
        public async Task Get_BigInteger_In_BigIntStorage_Should_Success()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<NumericValue, BigInteger>("storageBigInt");

            Assert.AreEqual(result, new BigInteger(5555687458961));
        }

        #endregion

        private static async Task<TOut> GetValueForSmartContract<T, TOut>(string methodName) where T : IBinaryType
        {
            var value = await SmartContract.QuerySmartContractWithAbiDefinition<T>(
                _provider,
                _scAddress,
                _abi,
                methodName);

            return value.ToObject<TOut>();
        }

        private static async Task<Transaction> InsertValueInSmartContract(string methodName, IBinaryType[] args)
        {
            var gasLimit = new GasLimit(6000000);
            var request = EGLDTransactionRequest.EGLDTransferToSmartContract(_networkConfig, _account, _scAddress, gasLimit, ESDTAmount.Zero(), methodName, args);

            var signedTransaction = _walletSigner.SignTransaction(request);
            var response = await _gatewayProvider.SendTransaction(signedTransaction);
            var transaction = Transaction.From(response.TxHash);
            await transaction.AwaitExecuted(_provider);
            _account.IncrementNonce();
            return transaction;
        }

        private static async Task ExecuteAndValidateAddTest(IBinaryType[] args, string methodName)
        {
            try
            {
                var transaction = await InsertValueInSmartContract(methodName, args);

                Assert.AreEqual(transaction.Status, "success");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private static async Task InitializeAsync()
        {
            //_scAddress = Address.FromBech32("erd1qqqqqqqqqqqqqpgq2ufgtg6zu2kuzzgrydpskjmwx9htp722ge3qvexkqf");

            if (!_isInitialized)
            {
                _isInitialized = true;
                _wallet = Wallet.FromPemFile("walletKey.pem");
                _provider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
                _gatewayProvider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
                _networkConfig = await NetworkConfig.GetFromNetwork(_provider);
                _walletSigner = _wallet.GetSigner();
                _account = _wallet.GetAccount();
                _abi = AbiDefinition.FromFilePath("TypeValueContract/typevalue.abi.json");
                await _account.Sync(_provider);

                var code = CodeArtifact.FromFilePath("TypeValueContract/typevalue.wasm");
                var codeMetaData = new CodeMetadata(true, true, false);
                var contractRequest = TransactionRequest.CreateDeploySmartContractTransactionRequest(_networkConfig, _account, code, codeMetaData);
                var signedTransaction = _walletSigner.SignTransaction(contractRequest);
                var response = await _gatewayProvider.SendTransaction(signedTransaction);
                var transaction = Transaction.From(response.TxHash);
                _scAddress = SmartContract.ComputeAddress(contractRequest);
                await transaction.AwaitExecuted(_provider);
                _account.IncrementNonce();
            }
        }
    }
}
