using System;
using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal abstract record ExternType;

internal record FunctionType : ExternType
{
    public List<ValueType> Parameters { get; }
    public List<ValueType> Results { get; }

    public FunctionType(IEnumerable<ValueType>? parameters = null, IEnumerable<ValueType>? results = null)
    {
        Parameters = parameters?.ToList() ?? new();
        Results = results?.ToList() ?? new();
    }

    public int ParamCount => Parameters.Count;
    public int ResultCount => Results.Count;

    public virtual bool Equals(FunctionType? other)
    {
        return ReferenceEquals(this, other) ||
            other is not null &&
            EqualityContract == other.EqualityContract &&
            Parameters.SequenceEqual(other.Parameters) &&
            Results.SequenceEqual(other.Results);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(EqualityContract);
        foreach (var parameter in Parameters)
        {
            hashCode.Add(parameter);
        }
        foreach (var result in Results)
        {
            hashCode.Add(result);
        }
        return hashCode.ToHashCode();
    }
}

internal record MemoryType(uint Min, uint? Max = null) : ExternType;

internal record TableType(ReferenceType ReferenceType, uint Min, uint? Max = null) : ExternType;

internal record GlobalType(ValueType ValueType, bool Mutable = false) : ExternType;