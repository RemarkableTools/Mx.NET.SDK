namespace Mx.NET.SDK.Provider.Dtos.Gateway.Addresses
{
    public class AccountDataDto
    {
        public AccountDto Account { get; set; }
    }

    public class AccountDto
    {
        public string Address { get; set; }
        public ulong Nonce { get; set; }
        public string Balance { get; set; }
        public string Username { get; set; }
    }
}
