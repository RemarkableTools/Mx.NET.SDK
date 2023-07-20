using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Mx.NET.SDK.Core.Domain.Values;

namespace Mx.NET.SDK.Core.Domain.Abi
{
    public class AbiDefinition
    {
        public string Name { get; set; }
        public Abi.Endpoint[] Endpoints { get; set; }
        public Dictionary<string, Abi.CustomTypes> Types { get; set; }

        public EndpointDefinition GetEndpointDefinition(string endpoint)
        {
            var data = Endpoints.ToList().SingleOrDefault(s => s.Name == endpoint);
            if (data == null)
                throw new Exception("Endpoint is not defined in ABI");

            var inputs = data.Inputs.Select(i => new FieldDefinition(i.Name, "", GetTypeValue(i.Type))).ToList();
            var outputs = data.Outputs.Select(i => new FieldDefinition("", "", GetTypeValue(i.Type))).ToList();
            return new EndpointDefinition(endpoint, inputs.ToArray(), outputs.ToArray());
        }

        private TypeValue GetTypeValue(string rustType)
        {
            var optional = new Regex("^optional<(.*)>$");
            var multi = new Regex("^multi<(.*)>$");
            var tuple = new Regex("^tuple<(.*)>$");
            var variadic = new Regex("^variadic<(.*)>$");
            var list = new Regex("^List<(.*)>$");
            var array = new Regex("^Array<(.*)>$");

            if (optional.IsMatch(rustType))
            {
                var innerType = optional.Match(rustType).Groups[1].Value;
                var innerTypeValue = GetTypeValue(innerType);
                return TypeValue.OptionValue(innerTypeValue);
            }

            if (multi.IsMatch(rustType))
            {
                var innerTypes = multi.Match(rustType).Groups[1].Value.Split(',').Where(s => !string.IsNullOrEmpty(s));
                var innerTypeValues = innerTypes.Select(GetTypeValue).ToArray();
                return TypeValue.MultiValue(innerTypeValues);
            }

            if (tuple.IsMatch(rustType))
            {
                var innerTypes = tuple.Match(rustType).Groups[1].Value.Split(',').Where(s => !string.IsNullOrEmpty(s));
                var innerTypeValues = innerTypes.Select(GetTypeValue).ToArray();
                return TypeValue.TupleValue(innerTypeValues);
            }

            if (variadic.IsMatch(rustType))
            {
                var innerType = variadic.Match(rustType).Groups[1].Value;
                var innerTypeValue = GetTypeValue(innerType);
                return TypeValue.VariadicValue(innerTypeValue);
            }

            if (list.IsMatch(rustType))
            {
                var innerType = list.Match(rustType).Groups[1].Value;
                var innerTypeValue = GetTypeValue(innerType);
                return TypeValue.ListValue(innerTypeValue);
            }
            if (array.IsMatch(rustType))
            {
                var innerType = list.Match(rustType).Groups[1].Value;
                var innerTypeValue = GetTypeValue(innerType);
                return TypeValue.ArrayValue(innerTypeValue);
            }

            var typeFromBaseRustType = TypeValue.FromRustType(rustType);
            if (typeFromBaseRustType != null)
                return typeFromBaseRustType;

            if (Types.Keys.Contains(rustType))
            {
                var typeFromStruct = Types[rustType];
                if (typeFromStruct.Type == "enum")
                {
                    return TypeValue.EnumValue(typeFromStruct.Type,
                                               typeFromStruct.Variants?
                                                    .ToList()
                                                    .Select(c => new FieldDefinition(c.Name, "", GetTypeValue(TypeValue.FromRustType("Enum").RustType)))
                                                    .ToArray());
                }
                else if (typeFromStruct.Type == "struct")
                {
                    return TypeValue.StructValue(typeFromStruct.Type,
                                                 typeFromStruct.Fields?
                                                    .ToList()
                                                    .Select(c => new FieldDefinition(c.Name, "", GetTypeValue(c.Type)))
                                                    .ToArray());

                }
            }

            return null;
        }

        public static AbiDefinition FromJson(string json)
        {
            return Helper.JsonWrapper.Deserialize<AbiDefinition>(json);
        }

        public static AbiDefinition FromFilePath(string jsonFilePath)
        {
            var fileBytes = File.ReadAllBytes(jsonFilePath);
            var json = Encoding.UTF8.GetString(fileBytes);
            return FromJson(json);
        }
    }
}
