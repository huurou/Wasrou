namespace Wasrou.Structure;

internal class Global
{
    public GlobalType Type { get; }
    public Expression Init { get; }

    public Global(GlobalType type, Expression init)
    {
        Type = type;
        Init = init;
    }
}