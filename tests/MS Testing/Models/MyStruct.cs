using Mx.NET.SDK.Core.Domain.Helper;

namespace MSTesting.Models
{
    public class MyStruct
    {
        public MyStruct(string name, long long_value)
        {
            Name = Converter.HexToString(name);
            LongValue = long_value;
        }
        public string Name { get; set; }
        public long LongValue { get; set; }
    }

    public class MyStruct2
    {
        public MyStruct2(string name, long long_value, List<bool> list_bool)
        {
            Name = Converter.HexToString(name);
            LongValue = long_value;
            BoolValues = list_bool;

        }
        public string Name { get; set; }
        public long LongValue { get; set; }
        public List<bool> BoolValues { get; set; }
    }
}
