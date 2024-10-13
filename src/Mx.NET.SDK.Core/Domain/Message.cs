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

        public byte[] Data { get; set; }
        public byte[] Signature { get; set; }
        public Address Address { get; set; }
        public int Version { get; set; } = DEFAULT_MESSAGE_VERSION;
        public string Signer { get; set; } = SDK_DOTNET_SIGNER;

        public Message() { }

        public Message(byte[] data)
        {
            Data = data;
        }

        public Message(byte[] data, byte[] signature)
        {
            Data = data;
            Signature = signature;
        }

        public byte[] SerializeForSigning()
        {
            var messageSize = Encoding.UTF8.GetBytes($"{Data.Length}");
            var message = messageSize.Concat(Data).ToArray();
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
            return Data;
        }
    }
}
