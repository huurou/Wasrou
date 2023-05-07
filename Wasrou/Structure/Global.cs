namespace Wasrou.Structure;

internal class Global
{
    internal GlobalType Type { get; init; }
    internal Expression Init { get; init; }

    internal Global(GlobalType type, Expression init)
    {
        Type = type;
        Init = init;
    }
}