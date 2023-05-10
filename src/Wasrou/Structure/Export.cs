namespace Wasrou.Structure;

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