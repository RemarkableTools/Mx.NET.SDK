using Mx.NET.SDK.Configuration;
using Mx.NET.SDK.Provider;
using Mx.NET.SDK.Domain.Data.Network;
using Mx.NET.SDK.Domain.Data.Transaction;
using Mx.NET.SDK.Domain.Data.Account;
using Mx.NET.SDK.Domain.Exceptions;
using Mx.NET.SDK.Core.Domain.Values;
using Mx.NET.SDK.Wallet.Wallet;
using System.Security.Principal;
using Mx.NET.SDK.TransactionsManager;
using Mx.NET.SDK.Core.Domain;
using Mx.NET.SDK.Wallet;

//var provider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.MainNet));
var provider = new MultiversxProvider(new MultiversxNetworkConfiguration(Network.DevNet));
var networkConfig = await NetworkConfig.GetFromNetwork(provider);
string filePath = "erd16nlhrnlm30qkpy8q52u95aaw0gjtx33xmlp62g5p4kj4mje04drq5y2tlw.json";
var password = "W4aog(testW)!";
var signer = Signer.FromKeyFile(filePath, password);
var account = Account.From(await provider.GetAccount(signer.GetAddress().Bech32));
var receiverAddress = Address.FromBech32("erd1ysrfrcysz54460rhmvqm43rn7jmugkh2zl5eahmywn9yap55hfkq0sjqzy");

var transactionRequest = EGLDTransactionRequest.EGLDTransfer(
    networkConfig,
    account,
    receiverAddress,
    ESDTAmount.EGLD("0.004"));

var signedTransaction = transactionRequest.Sign(signer);
var response = await provider.SendTransaction(signedTransaction);
var transaction = Transaction.From(response.TxHash);
await transaction.AwaitExecuted(provider);
Console.WriteLine($"Transaction executed with status {transaction.Status}");

////var tx = Transaction.From("9bae75c79db17dc87b96d37d491506cef15cfd1ca1f3e3a977266d9572c3cab7");
////var tx = Transaction.From("9ed2609a1daf50148e5e27505b4208ee69b9867fb5ec43ca322740bd8f71374b");
//var tx = Transaction.From("2a2a8850c8c1c9c091d9402b6d8747b8deb743a7f309d473eb35a772f669b3b2");

//try
//{
//    await tx.AwaitExecuted(provider);
//}
//catch (TransactionException.TransactionStatusNotReachedException) { }
//catch (TransactionException.TransactionWithSmartContractErrorException) { }
//catch (TransactionException.FailedTransactionException) { }
//catch (TransactionException.InvalidTransactionException) { }
//finally
//{
//    Console.WriteLine(tx.Status);
//}

//var address = Address.From("erd13dzua2hzdpedeh5zz5yxf2xu3uxuhjknw3ufdd3elwas44nf9esqaquxqq");

Console.WriteLine("\nEND PROGRAM...\nPress any key to close.");
Console.ReadKey();