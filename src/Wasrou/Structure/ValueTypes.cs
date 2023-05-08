namespace Wasrou.Structure;

internal abstract class ValueType
{
}

internal abstract class NumberType : ValueType
{
}

internal abstract class VectorType : ValueType
{
}

internal abstract class ReferenceType : ValueType
{
}

internal class I32 : NumberType
{
    public static I32 Instance { get; } = new();

    private I32()
    {
    }
}

internal class I64 : NumberType
{
    public static I64 Instance { get; } = new();

    private I64()
    {
    }
}

internal class F32 : NumberType
{
    public static F32 Instance { get; } = new();

    private F32()
    {
    }
}

internal class F64 : NumberType
{
    public static F64 Instance { get; } = new();

    private F64()
    {
    }
}

internal class V128 : VectorType
{
    public static V128 Instance { get; } = new();

    private V128()
    {
    }
}

internal class FunctionReference : ReferenceType
{
    public static FunctionReference Instance { get; } = new();

    private FunctionReference()
    {
    }
}

internal class ExternalReference : ReferenceType
{
    public static ExternalReference Instance { get; } = new();

    private ExternalReference()
    {
    }
}