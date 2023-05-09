using Wasrou.Structure;

namespace Wasrou.Binary;

internal class Import
{
    public string Module { get; }
    public string Name { get; }
    public ImportDesc Desc { get; }

    public Import(string module, string name, ImportDesc desc)
    {
        Module = module;
        Name = name;
        Desc = desc;
    }

    internal abstract class ImportDesc
    {
    }

    internal class ImportDescFunction : ImportDesc
    {
        public TypeIndex Value { get; }

        public ImportDescFunction(TypeIndex value)
        {
            Value = value;
        }
    }

    internal class ImportDescTable : ImportDesc
    {
        public TableType Value { get; }

        public ImportDescTable(TableType value)
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
}