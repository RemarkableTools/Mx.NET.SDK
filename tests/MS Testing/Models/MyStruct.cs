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
}
