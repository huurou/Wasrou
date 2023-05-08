namespace Wasrou.Structure;

internal class Export
{
    internal string Name { get; }
    internal ExportDesc Desc { get; }

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
    internal FunctionIndex Value { get; }

    internal ExportDescFunc(FunctionIndex value)
    {
        Value = value;
    }
}

internal class ExportDescTable : ExportDesc
{
    internal TableIndex Value { get; }

    internal ExportDescTable(TableIndex value)
    {
        Value = value;
    }
}

internal class ExportDescMemory : ExportDesc
{
    internal MemoryIndex Value { get; }

    internal ExportDescMemory(MemoryIndex value)
    {
        Value = value;
    }
}

internal class ExportDescGlobal : ExportDesc
{
    internal GlobalIndex Value { get; }

    internal ExportDescGlobal(GlobalIndex value)
    {
        Value = value;
    }
}