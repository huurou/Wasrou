namespace Wasrou.Structure;

internal class Import
{
    public string Name { get; }
    public ImportDesc Desc { get; }

    public Import(string name, ImportDesc desc)
    {
        Name = name;
        Desc = desc;
    }
}

internal abstract class ImportDesc
{
}

internal class ImportDescFunc : ImportDesc
{
    public TypeIndex Value { get; }

    public ImportDescFunc(TypeIndex value)
    {
        Value = value;
    }
}

internal class ImportDescTable : ImportDesc
{
    public TableIndex Value { get; }

    public ImportDescTable(TableIndex value)
    {
        Value = value;
    }
}

internal class ImportDescMemory : ImportDesc
{
    public MemoryType Value { get; }

    public ImportDescMemory(MemoryType value)
    {
        Value = value;
    }
}

internal class ImportDescGlobal : ImportDesc
{
    public GlobalType Value { get; }

    public ImportDescGlobal(GlobalType value)
    {
        Value = value;
    }
}