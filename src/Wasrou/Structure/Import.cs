namespace Wasrou.Structure;

internal class Import
{
    internal string Name { get; }
    internal ImportDesc Desc { get; }

    internal Import(string name, ImportDesc desc)
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
    internal TypeIndex Value { get; }

    internal ImportDescFunc(TypeIndex value)
    {
        Value = value;
    }
}

internal class ImportDescTable : ImportDesc
{
    internal TableIndex Value { get; }

    internal ImportDescTable(TableIndex value)
    {
        Value = value;
    }
}

internal class ImportDescMemory : ImportDesc
{
    internal MemoryType Value { get; }

    internal ImportDescMemory(MemoryType value)
    {
        Value = value;
    }
}

internal class ImportDescGlobal : ImportDesc
{
    internal GlobalType Value { get; }

    internal ImportDescGlobal(GlobalType value)
    {
        Value = value;
    }
}