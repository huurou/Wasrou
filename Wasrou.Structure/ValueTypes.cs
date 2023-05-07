namespace Wasrou.Structure;

public abstract class ValueType
{
}

public abstract class NumberType : ValueType
{
}

public abstract class VectorType : ValueType
{
}

public abstract class ReferenceType : ValueType
{
}

public class I32 : NumberType
{
    public static I32 Instance { get; } = new();

    private I32()
    {
    }
}

public class I64 : NumberType
{
    public static I64 Instance { get; } = new();

    private I64()
    {
    }
}

public class F32 : NumberType
{
    public static F32 Instance { get; } = new();

    private F32()
    {
    }
}

public class F64 : NumberType
{
    public static F64 Instance { get; } = new();

    private F64()
    {
    }
}

public class V128 : VectorType
{
    public static V128 Instance { get; } = new();

    private V128()
    {
    }
}

public class FunctionReference : ReferenceType
{
    public static FunctionReference Instance { get; } = new();

    private FunctionReference()
    {
    }
}

public class ExternalReference : ReferenceType
{
    public static ExternalReference Instance { get; } = new();

    private ExternalReference()
    {
    }
}