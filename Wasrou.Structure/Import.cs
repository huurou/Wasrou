namespace Wasrou.Structure;

public class Import
{
    public string Name { get; init; }
    public ImportDesc Desc { get; init; }

    public Import(string name, ImportDesc desc)
    {
        Name = name;
        Desc = desc;
    }
}

public abstract class ImportDesc
{
}

public class ImportDescFunc : ImportDesc
{
    public TypeIndex Value { get; init; }

    public ImportDescFunc(TypeIndex value)
    {
        Value = value;
    }
}

public class ImportDescTable : ImportDesc
{
    public TableIndex Value { get; init; }

    public ImportDescTable(TableIndex value)
    {
        Value = value;
    }
}

public class ImportDescMemory : ImportDesc
{
    public MemoryType Value { get; init; }

    public ImportDescMemory(MemoryType value)
    {
        Value = value;
    }
}

public class ImportDescGlobal : ImportDesc
{
    public GlobalType Value { get; init; }

    public ImportDescGlobal(GlobalType value)
    {
        Value = value;
    }
}