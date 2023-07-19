namespace Mx.NET.SDK.Provider.Dtos.Gateway.Transactions
{
    public class SmartContractResultDto
    {
        public string Hash { get; set; }
        public long Nonce { get; set; }
        public long Value { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string? Data { get; set; }
        public string ReturnMessage { get; set; }
        public string PrevTxHash { get; set; }
        public string OriginalTxHash { get; set; }
        public long GasLimit { get; set; }
        public long GasPrice { get; set; }
        public long CallType { get; set; }
        public string Operation { get; set; }
        public string Function { get; set; }
    }
}
