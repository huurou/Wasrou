using System.IO;

namespace Wasrou.Binary;

internal static class BinaryDecoder
{
    public static Module Decode(Stream stream)
    {
        using var br = new BinaryReader(stream);
        try
        {
            return new Module(br);
        }
        catch (EndOfStreamException eosex)
        {
            throw new WasmException(Error.バイナリが途中で終わっています, eosex);
        }
    }
}