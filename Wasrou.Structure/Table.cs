namespace Wasrou.Structure;

public class Table
{
    public TableType Type { get; init; }

    public Table(TableType type)
    {
        Type = type;
    }
}