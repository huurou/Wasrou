using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Function
{
    public TypeIndex Type { get; }
    public List<ValueType> Locals { get; }
    public Expression Body { get; }

    public Function(TypeIndex type, IEnumerable<ValueType>? locals = null, Expression? body = null)
    {
        Type = type;
        Locals = locals?.ToList() ?? new();
        Body = body ?? new();
    }
}