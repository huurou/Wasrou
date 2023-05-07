namespace Wasrou.Structure;

public class Global
{
    public GlobalType Type { get; init; }
    public Expression Init { get; init; }

    public Global(GlobalType type, Expression init)
    {
        Type = type;
        Init = init;
    }
}