using System.Collections.Generic;
using System.IO;
using Wasrou.Structure;

namespace Wasrou.Binary;

internal class FunctionSection
{
    public List<TypeIndex> TypeIndices { get; } = new();

    public FunctionSection(BinaryReader br)
    {
        var n = br.ReadLEB128Uint32();
        for (var i = 0; i < n; i++)
        {
            TypeIndices.Add(new(br.ReadLEB128Uint32()));
        }
    }
}