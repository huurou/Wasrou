using System.IO;

namespace Wasrou.Binary;

internal class CustomSection
{
    public string Name { get; }
    public byte[] Data { get; }

    public CustomSection(BinaryReader br, uint size)
    {
        Name = Common.GetName(br);
        Data = br.ReadBytes((int)(size - Name.Length - 1));
    }
}