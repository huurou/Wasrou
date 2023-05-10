using System.Collections.Generic;
using System.IO;
using Wasrou.Structure;

namespace Wasrou.Binary;

internal class TypeSection
{
    public List<FunctionType> FunctionTypes { get; } = new();

    public TypeSection(BinaryReader br)
    {
        var n = br.ReadLEB128Uint32();
        for (var i = 0; i < n; i++)
        {
            var code = (TypeCode)br.ReadByte();
            switch (code)
            {
                case TypeCode.Function:
                    FunctionTypes.Add(ReadFunctionType(br));
                    break;

                default:
                    throw new WasmException(Error.TypeSectionのタイプコードが不正です);
            }
        }
    }

    private static FunctionType ReadFunctionType(BinaryReader br)
    {
        var n = (int)br.ReadLEB128Uint32();
        var parameters = new List<ValueType>(n);
        for (var i = 0; i < n; i++)
        {
            parameters.Add(Common.GetValueType(br));
        }
        var m = (int)br.ReadLEB128Uint32();
        var results = new List<ValueType>(m);
        for (var i = 0; i < m; i++)
        {
            results.Add(Common.GetValueType(br));
        }
        return new(parameters, results);
    }
}