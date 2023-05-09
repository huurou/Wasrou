using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        var parameters = Enumerable.Range(0, n).Select(_ => Common.GetValueType(br));
        var m = (int)br.ReadLEB128Uint32();
        var results = Enumerable.Range(0, m).Select(_ => Common.GetValueType(br));
        return new(parameters, results);
    }
}