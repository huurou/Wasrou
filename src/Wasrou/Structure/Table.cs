namespace Wasrou.Structure;

internal class Table
{
    internal TableType Type { get; }

    internal Table(TableType type)
    {
        Type = type;
    }
}