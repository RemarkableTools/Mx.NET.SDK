using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Core.Domain;
using Mx.NET.SDK.Core.Domain.Abi;
using Mx.NET.SDK.Core.Domain.SmartContracts;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Domain;
using Mx.NET.SDK.Domain.Data.Accounts;
using Mx.NET.SDK.Domain.Data.Network;
using Mx.NET.SDK.Domain.Data.Transactions;
using Mx.NET.SDK.Domain.SmartContracts;
using Mx.NET.SDK.Provider;
using Mx.NET.SDK.TransactionsManager;
using Mx.NET.SDK.Wallet;
using Mx.NET.SDK.Wallet.Wallet;

namespace MSTesting.TypeValueTesting
{
    public abstract class TypeValueBaseTesting
    {
        private static Wallet _wallet;
        private static IApiProvider _apiProvider;
        private static Address? _scAddress;
        private static WalletSigner _walletSigner;
        private static AbiDefinition _abi;
        private static NetworkConfig? _networkConfig;
        private static Account _account;
        private static bool _isInitialized;

        public static async Task<TOut> GetValueForSmartContract<T, TOut>(string methodName) where T : IBinaryType
        {
            var value = await SmartContract.QuerySmartContractWithAbiDefinition<T>(
                _apiProvider,
                _scAddress,
                _abi,
                methodName);

            return value.ToObject<TOut>();
        }

        public static async Task<Transaction> InsertValueInSmartContract(string methodName, IBinaryType[] args)
        {
            var gasLimit = new GasLimit(6000000);
            var insertRequest = EGLDTransactionRequest.EGLDTransferToSmartContract(_networkConfig, _account, _scAddress, gasLimit, ESDTAmount.Zero(), methodName, args);

            var signature = _walletSigner.SignTransaction(insertRequest.SerializeForSigning());
            var signedTransaction = insertRequest.ApplySignature(signature);
            var response = await _apiProvider.SendTransaction(signedTransaction);
            var transaction = Transaction.From(response.TxHash);
            await transaction.AwaitExecuted(_apiProvider);
            _account.IncrementNonce();
            return transaction;
        }

        public static async Task ExecuteAndValidateAddTest(IBinaryType[] args, string methodName)
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

        public static async Task InitializeAsync()
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                _wallet = Wallet.FromPemFile("./walletKey.pem");
                _apiProvider = new ApiProvider(new ApiNetworkConfiguration(Network.DevNet));
                _networkConfig = await NetworkConfig.GetFromNetwork(_apiProvider);
                _walletSigner = _wallet.GetSigner();
                _account = new Account(_wallet.GetAddress());
                _abi = AbiDefinition.FromFilePath("../../../TypeValueTesting/TypeValueContract/typevalue.abi.json");
                await _account.Sync(_apiProvider);

                var code = CodeArtifact.FromFilePath("../../../TypeValueTesting/TypeValueContract/typevalue.wasm");
                var codeMetaData = new CodeMetadata(true, true, false);
                var contractRequest = SmartContractTransactionRequest.Deploy(_networkConfig, _account, code, codeMetaData);
                var signature = _walletSigner.SignTransaction(contractRequest.SerializeForSigning());
                var signedTransaction = contractRequest.ApplySignature(signature);
                var response = await _apiProvider.SendTransaction(signedTransaction);
                var transaction = Transaction.From(response.TxHash);
                _scAddress = SmartContract.ComputeAddress(contractRequest);
                await transaction.AwaitExecuted(_apiProvider);
                _account.IncrementNonce();
            }
        }
    }
}
