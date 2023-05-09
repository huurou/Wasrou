namespace Wasrou.Structure;

internal abstract class ValueType
{
}

internal abstract class NumberType : ValueType
{
}

internal abstract class IntegerNumberType : ValueType
{
}

internal class I32 : IntegerNumberType
{
    public static I32 Instance { get; } = new();

    private I32()
    {
    }
}

internal class I64 : IntegerNumberType
{
    public static I64 Instance { get; } = new();

    private I64()
    {
    }
}

internal abstract class FloatNumberType : ValueType
{
}

internal class F32 : FloatNumberType
{
    public static F32 Instance { get; } = new();

    private F32()
    {
    }
}

internal class F64 : FloatNumberType
{
    public static F64 Instance { get; } = new();

    private F64()
    {
    }
}

internal abstract class VectorType : ValueType
{
}

internal class V128 : VectorType
{
    public static V128 Instance { get; } = new();

    private V128()
    {
    }
}

internal abstract class ReferenceType : ValueType
{
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