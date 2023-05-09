using System.IO;

namespace Wasrou.Binary;

internal static class BinaryDecoder
{
    public static void Decode(Stream stream)
    {
        using var br = new BinaryReader(stream);
        var binModule=new Module(br);
    }
}