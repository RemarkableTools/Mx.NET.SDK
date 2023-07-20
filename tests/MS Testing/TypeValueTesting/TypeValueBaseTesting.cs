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

namespace MSTesting.TypeValueTesting
{
    public abstract class TypeValueBaseTesting
    {
        private static Wallet _wallet;
        private static IGatewayProvider _gatewayProvider;
        private static MultiversxProvider _provider;
        private static Address? _scAddress;
        private static WalletSigner _walletSigner;
        private static AbiDefinition _abi;
        private static NetworkConfig? _networkConfig;
        private static Account _account;
        private static bool _isInitialized;

        public static async Task<TOut> GetValueForSmartContract<T, TOut>(string methodName) where T : IBinaryType
        {
            var value = await SmartContract.QuerySmartContractWithAbiDefinition<T>(
                _provider,
                _scAddress,
                _abi,
                methodName);

            return value.ToObject<TOut>();
        }

        public static async Task<Transaction> InsertValueInSmartContract(string methodName, IBinaryType[] args)
        {
            var gasLimit = new GasLimit(6000000);
            var request = EGLDTransactionRequest.EGLDTransferToSmartContract(_networkConfig, _account, _scAddress, gasLimit, ESDTAmount.Zero(), methodName, args);

            var signedTransaction = _walletSigner.SignTransaction(request);
            var response = await _provider.SendTransaction(signedTransaction);
            var transaction = Transaction.From(response.TxHash);
            await transaction.AwaitExecuted(_provider);
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
            //_scAddress = Address.FromBech32("erd1qqqqqqqqqqqqqpgqaruu67zvppyxpflr4406atetk94l3wjage3qg0tpec");

            if (!_isInitialized)
            {
                _isInitialized = true;
                _wallet = Wallet.FromPemFile("./walletKey.pem");
                _provider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
                //_gatewayProvider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
                _networkConfig = await NetworkConfig.GetFromNetwork(_provider);
                _walletSigner = _wallet.GetSigner();
                _account = _wallet.GetAccount();
                _abi = AbiDefinition.FromFilePath("./TypeValueContract/typevalue.abi.json");
                await _account.Sync(_provider);

                var code = CodeArtifact.FromFilePath("./TypeValueContract/typevalue.wasm");
                var codeMetaData = new CodeMetadata(true, true, false);
                var gasLimit = new GasLimit(100000000);
                var contractRequest = TransactionRequest.CreateDeploySmartContractTransactionRequest(_networkConfig, _account, code, codeMetaData);
                var signedTransaction = _walletSigner.SignTransaction(contractRequest);
                var response = await _provider.SendTransaction(signedTransaction);
                var transaction = Transaction.From(response.TxHash);
                _scAddress = SmartContract.ComputeAddress(contractRequest);
                await transaction.AwaitExecuted(_provider);
                _account.IncrementNonce();
            }
        }
    }
}
