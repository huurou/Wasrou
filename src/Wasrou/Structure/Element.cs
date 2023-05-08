using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Element
{
    internal ReferenceType Type { get; }
    internal List<Expression> Init { get; }
    internal ElementMode Mode { get; }

    internal Element(ReferenceType type, IEnumerable<Expression> init, ElementMode mode)
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
    internal TableIndex Table { get; }
    internal Expression Offset { get; }

    internal ElementModeActive(TableIndex table, Expression offset)
    {
        Table = table;
        Offset = offset;
    }
}

internal class ElementModeDeclarative : ElementMode
{
}