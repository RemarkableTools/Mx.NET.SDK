using System.Linq;
using System.Text;
using Mx.NET.SDK.Core.Domain.Values;
using Org.BouncyCastle.Crypto.Digests;

namespace Mx.NET.SDK.Core.Domain
{
    public class Message
    {
        const string MESSAGE_PREFIX = "\u0017Elrond Signed Message:\n";
        const int DEFAULT_MESSAGE_VERSION = 1;
        const string SDK_DOTNET_SIGNER = "sdk-dotnet";

        public string Data { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;
        public Address Address { get; set; }
        public int Version { get; set; } = DEFAULT_MESSAGE_VERSION;
        public string Signer { get; set; } = SDK_DOTNET_SIGNER;

        public Message() { }

        public Message(string message)
        {
            Data = message;
        }

        public Message(string message, string signature)
        {
            Data = message;
            Signature = signature;
        }

        public byte[] SerializeForSigning()
        {
            var messageSize = Encoding.UTF8.GetBytes($"{Data.Length}");
            var message = messageSize.Concat(Encoding.UTF8.GetBytes(Data)).ToArray();
            var messagePrefix = Encoding.UTF8.GetBytes(MESSAGE_PREFIX);
            var bytesToHash = messagePrefix.Concat(message).ToArray();

            var digest = new KeccakDigest(256);
            digest.BlockUpdate(bytesToHash, 0, bytesToHash.Length);
            var calculatedHash = new byte[digest.GetByteLength()];
            digest.DoFinal(calculatedHash, 0);
            var serializedMessage = calculatedHash.Take(32).ToArray();

            return serializedMessage;
        }

        public byte[] SerializeForSigningRaw()
        {
            return Encoding.UTF8.GetBytes(Data);
        }
    }
}
