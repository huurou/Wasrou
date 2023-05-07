using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

public class Element
{
    public ReferenceType Type { get; init; }
    public List<Expression> Init { get; init; }
    public ElementMode Mode { get; init; }

    public Element(ReferenceType type, IEnumerable<Expression> init, ElementMode mode)
    {
        Type = type;
        Init = init.ToList();
        Mode = mode;
    }
}

public abstract class ElementMode
{
}

public class ElementModePassive : ElementMode
{
}

public class ElementModeActive : ElementMode
{
    public TableIndex Table { get; init; }
    public Expression Offset { get; init; }

    public ElementModeActive(TableIndex table, Expression offset)
    {
        Table = table;
        Offset = offset;
    }
}

public class ElementModeDeclarative : ElementMode
{
}