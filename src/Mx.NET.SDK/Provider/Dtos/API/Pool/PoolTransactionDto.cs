namespace Mx.NET.SDK.Provider.Dtos.API.Pool
{
    public class PoolTransactionDto
    {
        public string TxHash { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string ReceiverUsername { get; set; }
        public string Guardian { get; set; }
        public string GuardianSignature { get; set; }
        public ulong Nonce { get; set; }
        public string Value { get; set; }
        public string Data { get; set; }
        public long GasPrice { get; set; }
        public long GasLimit { get; set; }
        public uint SenderShard { get; set; }
        public uint ReceiverShard { get; set; }
        public string Signature { get; set; }
        public string Type { get; set; }
    }
}
