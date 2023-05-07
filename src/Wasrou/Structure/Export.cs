namespace Wasrou.Structure;

internal class Export
{
    internal string Name { get; init; }
    internal ExportDesc Desc { get; init; }

    internal Export(string name, ExportDesc desc)
    {
        Name = name;
        Desc = desc;
    }
}

internal abstract class ExportDesc
{
}

internal class ExportDescFunc : ExportDesc
{
    internal FunctionIndex Value { get; init; }

    internal ExportDescFunc(FunctionIndex value)
    {
        Value = value;
    }
}

internal class ExportDescTable : ExportDesc
{
    internal TableIndex Value { get; init; }

    internal ExportDescTable(TableIndex value)
    {
        Value = value;
    }
}

internal class ExportDescMemory : ExportDesc
{
    internal MemoryIndex Value { get; init; }

    internal ExportDescMemory(MemoryIndex value)
    {
        Value = value;
    }
}

internal class ExportDescGlobal : ExportDesc
{
    internal GlobalIndex Value { get; init; }

    internal ExportDescGlobal(GlobalIndex value)
    {
        Value = value;
    }
}