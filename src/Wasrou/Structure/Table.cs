namespace Wasrou.Structure;

internal class Table
{
    internal TableType Type { get; init; }

    internal Table(TableType type)
    {
        Type = type;
    }
}