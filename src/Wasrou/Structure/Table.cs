namespace Wasrou.Structure;

internal class Table
{
    public TableType Type { get; }

    public Table(TableType type)
    {
        Type = type;
    }
}