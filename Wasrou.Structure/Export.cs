namespace Wasrou.Structure;

public class Export
{
    public string Name { get; init; }
    public ExportDesc Desc { get; init; }

    public Export(string name, ExportDesc desc)
    {
        Name = name;
        Desc = desc;
    }
}

public abstract class ExportDesc
{
}

public class ExportDescFunc : ExportDesc
{
    public FunctionIndex Value { get; init; }

    public ExportDescFunc(FunctionIndex value)
    {
        Value = value;
    }
}

public class ExportDescTable : ExportDesc
{
    public TableIndex Value { get; init; }

    public ExportDescTable(TableIndex value)
    {
        Value = value;
    }
}

public class ExportDescMemory : ExportDesc
{
    public MemoryIndex Value { get; init; }

    public ExportDescMemory(MemoryIndex value)
    {
        Value = value;
    }
}

public class ExportDescGlobal : ExportDesc
{
    public GlobalIndex Value { get; init; }

    public ExportDescGlobal(GlobalIndex value)
    {
        Value = value;
    }
}