using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

public class Function
{
    public TypeIndex Type { get; init; }
    public List<ValueType> Locals { get; init; }
    public Expression Body { get; init; }

    public Function(TypeIndex type, IEnumerable<ValueType>? locals = null, Expression? body = null)
    {
        Type = type;
        Locals = locals?.ToList() ?? new();
        Body = body ?? new();
    }
}