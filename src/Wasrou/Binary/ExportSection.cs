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
        var kind = (ExportKind)br.ReadByte();
        var index = br.ReadLEB128Uint32();
        var name = Common.GetName(br);
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
    public FunctionIndex Value { get; }

    public ExportDescFunction(FunctionIndex value)
    {
        Value = value;
    }
}

internal class ExportDescTable : ExportDesc
{
    public TableIndex Value { get; }

    public ExportDescTable(TableIndex value)
    {
        Value = value;
    }
}

internal class ExportDescMemory : ExportDesc
{
    public MemoryIndex Value { get; }

    public ExportDescMemory(MemoryIndex value)
    {
        Value = value;
    }
}

internal class ExportDescGlobal : ExportDesc
{
    public GlobalIndex Value { get; }

    public ExportDescGlobal(GlobalIndex value)
    {
        Value = value;
    }
}

internal enum ExportKind
{
    Function = 0x00,
    Table = 0x01,
    Memory = 0x02,
    Global = 0x03,
}