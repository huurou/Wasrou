using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Function
{
    internal TypeIndex Type { get; init; }
    internal List<ValueType> Locals { get; init; }
    internal Expression Body { get; init; }

    internal Function(TypeIndex type, IEnumerable<ValueType>? locals = null, Expression? body = null)
    {
        Type = type;
        Locals = locals?.ToList() ?? new();
        Body = body ?? new();
    }
}