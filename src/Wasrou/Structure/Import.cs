namespace Wasrou.Structure;

internal class Import
{
    internal string Name { get; init; }
    internal ImportDesc Desc { get; init; }

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
    internal TypeIndex Value { get; init; }

    internal ImportDescFunc(TypeIndex value)
    {
        Value = value;
    }
}

internal class ImportDescTable : ImportDesc
{
    internal TableIndex Value { get; init; }

    internal ImportDescTable(TableIndex value)
    {
        Value = value;
    }
}

internal class ImportDescMemory : ImportDesc
{
    internal MemoryType Value { get; init; }

    internal ImportDescMemory(MemoryType value)
    {
        Value = value;
    }
}

internal class ImportDescGlobal : ImportDesc
{
    internal GlobalType Value { get; init; }

    internal ImportDescGlobal(GlobalType value)
    {
        Value = value;
    }
}