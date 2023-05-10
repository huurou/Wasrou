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

internal abstract record ExportDesc
{
}

internal record ExportDescFunction(FunctionIndex Value) : ExportDesc;

internal record ExportDescTable(TableIndex Value) : ExportDesc;

internal record ExportDescMemory(MemoryIndex Value) : ExportDesc;

internal record ExportDescGlobal(GlobalIndex Value) : ExportDesc;