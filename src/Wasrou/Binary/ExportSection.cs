using System;
using System.Collections.Generic;
using System.IO;
using Wasrou.Structure;

namespace Wasrou.Binary;

internal class ExportSection
{
    public List<Export> Exports { get; } = new();

    public ExportSection(BinaryReader br)
    {
        var n = br.ReadLEB128Uint32();
        for (var i = 0; i < n; i++)
        {
            Exports.Add(ReadExport(br));
        }
    }

    private static Export ReadExport(BinaryReader br)
    {
        var name = Common.GetName(br);
        var kind = (ExportKind)br.ReadByte();
        var index = br.ReadLEB128Uint32();
        ExportDesc desc = kind switch
        {
            ExportKind.Function => new ExportDescFunction(new(index)),
            ExportKind.Table => new ExportDescTable(new(index)),
            ExportKind.Memory => new ExportDescMemory(new(index)),
            ExportKind.Global => new ExportDescGlobal(new(index)),
            _ => throw new NotImplementedException(),
        };
        return new(name, desc);
    }
}

internal class Export
{
    public string Name { get; }

    public ExportDesc Desc { get; }

    public Export(string name, ExportDesc desc)
    {
        Name = name;
        Desc = desc;
    }
}

internal abstract class ExportDesc
{
}

internal class ExportDescFunction : ExportDesc
{
    public FunctionIndex Index { get; }

    public ExportDescFunction(FunctionIndex index)
    {
        Index = index;
    }
}

internal class ExportDescTable : ExportDesc
{
    public TableIndex Index { get; }

    public ExportDescTable(TableIndex index)
    {
        Index = index;
    }
}

internal class ExportDescMemory : ExportDesc
{
    public MemoryIndex Index { get; }

    public ExportDescMemory(MemoryIndex index)
    {
        Index = index;
    }
}

internal class ExportDescGlobal : ExportDesc
{
    public GlobalIndex Index { get; }

    public ExportDescGlobal(GlobalIndex index)
    {
        Index = index;
    }
}

internal enum ExportKind
{
    Function = 0x00,
    Table = 0x01,
    Memory = 0x02,
    Global = 0x03,
}