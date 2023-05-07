using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Element
{
    internal ReferenceType Type { get; init; }
    internal List<Expression> Init { get; init; }
    internal ElementMode Mode { get; init; }

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
    internal TableIndex Table { get; init; }
    internal Expression Offset { get; init; }

    internal ElementModeActive(TableIndex table, Expression offset)
    {
        Table = table;
        Offset = offset;
    }
}

internal class ElementModeDeclarative : ElementMode
{
}