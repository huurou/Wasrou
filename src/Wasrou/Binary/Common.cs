using System.IO;
using System.Text;
using Wasrou.Structure;

namespace Wasrou.Binary;

internal static class Common
{
    public static ValueType GetValueType(BinaryReader br)
    {
        return (TypeCode)br.ReadByte() switch
        {
            TypeCode.I32 => new I32(),
            TypeCode.I64 => new I64(),
            TypeCode.F32 => new F32(),
            TypeCode.F64 => new F64(),
            TypeCode.V128 => new V128(),
            TypeCode.FuncRef => new FunctionReference(),
            TypeCode.ExternRef => new ExternalReference(),
            _ => throw new WasmException(Error.タイプコードが不正です),
        };
    }

    public static string GetName(BinaryReader br)
    {
        var length = br.ReadLEB128Uint32();
        return Encoding.UTF8.GetString(br.ReadBytes((int)length));
    }
}