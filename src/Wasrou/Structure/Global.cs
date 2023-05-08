namespace Wasrou.Structure;

internal class Global
{
    internal GlobalType Type { get; }
    internal Expression Init { get; }

    internal Global(GlobalType type, Expression init)
    {
        Type = type;
        Init = init;
    }
}