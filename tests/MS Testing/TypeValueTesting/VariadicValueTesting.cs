using Mx.NET.SDK.Core.Domain.Values;

namespace MSTesting.TypeValueTesting
{
    [TestClass]
    public class VariadicValueTesting : TypeValueBaseTesting
    {

        [TestMethod]
        public async Task Add_TokenIdentifier_ManagedAddress()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                ESDTIdentifierValue.From("WEGLD-01e49d"),
                Address.FromBech32("erd13zn08mldnvdpewqtxuhpjupkn33tfxp3x05ve7hvkw7nl3zhuyaqfmk0rc")
            };

            await ExecuteAndValidateAddTest(args, "insertVariadicTokenIdentifierManagedAddress");
        }

        [TestMethod]
        public async Task Get_TokenIdentifier_ManagedAddress()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<VariadicValue, List<MultiValue>>("getVariadicTokenIdentifierManagedAddress");

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public async Task Add_ManagedAddress()
        {

            await InitializeAsync();

            var args = new IBinaryType[]
            {
                Address.FromBech32("erd1l6h0hrxskv0kuyz67fcfeyj2ckwfjsc8c9tqyc2k93hcgrdll5qqzk6ej4")
            };

            await ExecuteAndValidateAddTest(args, "insertVariadicManagedAddress");
        }

        [TestMethod]
        public async Task Get_ManagedAddress()
        {
            await InitializeAsync();

            var result = await GetValueForSmartContract<VariadicValue, List<Address>>("getVariadicManagedAddress");

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Bech32, "erd1l6h0hrxskv0kuyz67fcfeyj2ckwfjsc8c9tqyc2k93hcgrdll5qqzk6ej4");
        }
    }
}
