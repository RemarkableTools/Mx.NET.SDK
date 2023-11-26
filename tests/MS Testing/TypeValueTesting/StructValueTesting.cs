using MSTesting.TypeValueTesting.Models;
using Mx.NET.SDK.Core.Domain.Values;

namespace MSTesting.TypeValueTesting
{
    [TestClass]
    public class StructValueTesting : TypeValueBaseTesting
    {
        [TestMethod]
        public async Task Add_MyStruct()
        {
            await InitializeAsync();

            var fieldDefinition = new FieldDefinition[2]
            {
                new FieldDefinition("name", "", TypeValue.BytesValue),
                new FieldDefinition("long_value", "", TypeValue.U64TypeValue),
            };

            var fields = new Field[2]
            {
                new Field("name", BytesValue.FromUtf8("test")),
                new Field("long_value", NumericValue.U64Value(522))

            };

            var args = new IBinaryType[]
            {
                new StructValue(TypeValue.StructValue("TestStruct", fieldDefinition), fields)
            };

            await ExecuteAndValidateAddTest(args, "insertMyStruct");
        }

        [TestMethod]
        public async Task Get_MyStruct()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<StructValue, MyStruct>("getMyStruct");


            Assert.AreEqual(result.Name, "test");
            Assert.AreEqual(result.LongValue, 522);
        }

        [TestMethod]
        public async Task Add_MyStruct2()
        {
            await InitializeAsync();

            var fieldDefinition = new FieldDefinition[3]
            {
                new FieldDefinition("name", "", TypeValue.BytesValue),
                new FieldDefinition("long_value", "", TypeValue.U64TypeValue),
                new FieldDefinition("list_bool", "", TypeValue.ListValue(TypeValue.BooleanValue)),
            };

            var fields = new Field[3]
            {
                new Field("name", BytesValue.FromUtf8("test")),
                new Field("long_value", NumericValue.U64Value(522)),
                new Field("list_bool", ListValue.From(TypeValue.BooleanValue, new IBinaryType[]{ BooleanValue.From(true), BooleanValue.From(false), BooleanValue.From(true)})),

            };

            var args = new IBinaryType[]
            {
                new StructValue(TypeValue.StructValue("TestStruct", fieldDefinition), fields)
            };

            await ExecuteAndValidateAddTest(args, "insertMyStruct2");
        }

        [TestMethod]
        public async Task Get_MyStruct2()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<StructValue, MyStruct2>("getMyStruct2");


            Assert.AreEqual(result.Name, "test");
            Assert.AreEqual(result.LongValue, 522);
            Assert.AreEqual(result.BoolValues.Count, 3);
            Assert.AreEqual(result.BoolValues[0], true);
            Assert.AreEqual(result.BoolValues[1], false);
            Assert.AreEqual(result.BoolValues[2], true);
        }

        [TestMethod]
        public async Task Add_ManagedVec_MyStruct2()
        {
            await InitializeAsync();

            var fieldDefinition = new FieldDefinition[3]
            {
                new FieldDefinition("name", "", TypeValue.BytesValue),
                new FieldDefinition("long_value", "", TypeValue.U64TypeValue),
                new FieldDefinition("list_bool", "", TypeValue.ListValue(TypeValue.BooleanValue)),
            };

            var myStruct1Fields = new Field[3]
            {
                new Field("name", BytesValue.FromUtf8("test")),
                new Field("long_value", NumericValue.U64Value(522)),
                new Field("list_bool", ListValue.From(TypeValue.BooleanValue, new IBinaryType[]{ BooleanValue.From(true), BooleanValue.From(false), BooleanValue.From(true)})),

            };

            var myStruct2Fields = new Field[3]
            {
                new Field("name", BytesValue.FromUtf8("struct2")),
                new Field("long_value", NumericValue.U64Value(9866475528)),
                new Field("list_bool", ListValue.From(TypeValue.BooleanValue, new IBinaryType[]{ BooleanValue.From(false), BooleanValue.From(false), BooleanValue.From(true)})),

            };

            var struct1 = new StructValue(TypeValue.StructValue("TestStruct", fieldDefinition), myStruct1Fields);
            var struct2 = new StructValue(TypeValue.StructValue("TestStruct", fieldDefinition), myStruct2Fields);


            var listValue = ListValue.From(TypeValue.StructValue("TestStruct", fieldDefinition), new StructValue[] { struct1, struct2 });

            var args = new IBinaryType[]
            {
                listValue
            };

            await ExecuteAndValidateAddTest(args, "insertManagedVecMyStruct2");
        }

        [TestMethod]
        public async Task Get_ManagedVec_MyStruct2()
        {
            await InitializeAsync();
            var result = await GetValueForSmartContract<ListValue, List<MyStruct2>>("getManagedVecMyStruct2");

            Assert.AreEqual(result.Count, 2);
            var firstMyStruct2 = result[0];
            Assert.AreEqual(firstMyStruct2.Name, "test");
            Assert.AreEqual(firstMyStruct2.LongValue, 522);
            Assert.AreEqual(firstMyStruct2.BoolValues.Count, 3);
            Assert.AreEqual(firstMyStruct2.BoolValues[0], true);
            Assert.AreEqual(firstMyStruct2.BoolValues[1], false);
            Assert.AreEqual(firstMyStruct2.BoolValues[2], true);

            var secondMyStruct2 = result[1];
            Assert.AreEqual(secondMyStruct2.Name, "struct2");
            Assert.AreEqual(secondMyStruct2.LongValue, 9866475528);
            Assert.AreEqual(secondMyStruct2.BoolValues.Count, 3);
            Assert.AreEqual(secondMyStruct2.BoolValues[0], false);
            Assert.AreEqual(secondMyStruct2.BoolValues[1], false);
            Assert.AreEqual(secondMyStruct2.BoolValues[2], true);
        }
    }
}
