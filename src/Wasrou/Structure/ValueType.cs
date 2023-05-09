namespace Wasrou.Structure;

internal abstract class ValueType
{
}

internal abstract class NumberType : ValueType
{
}

internal abstract class IntegerNumberType : NumberType
{
}

internal class I32 : IntegerNumberType
{
}

internal class I64 : IntegerNumberType
{
}

internal abstract class FloatNumberType : NumberType
{
}

internal class F32 : FloatNumberType
{
}

internal class F64 : FloatNumberType
{
}

internal abstract class VectorType : ValueType
{
}

internal class V128 : VectorType
{
}

internal abstract class ReferenceType : ValueType
{
}

internal class FunctionReference : ReferenceType
{
}

internal class ExternalReference : ReferenceType
{
}