using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Element
{
    public ReferenceType Type { get; }
    public List<Expression> Init { get; }
    public ElementMode Mode { get; }

    public Element(ReferenceType type, IEnumerable<Expression> init, ElementMode mode)
    {
        Type = type;
        Init = init.ToList();
        Mode = mode;
    }
}

internal abstract class ElementMode
{
}

internal class ElementModePassive : ElementMode
{
}

internal class ElementModeActive : ElementMode
{
    public TableIndex Table { get; }
    public Expression Offset { get; }

    public ElementModeActive(TableIndex table, Expression offset)
    {
        Table = table;
        Offset = offset;
    }
}

internal class ElementModeDeclarative : ElementMode
{
}