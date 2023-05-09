namespace Wasrou.Structure;

internal abstract class NumericOperator : NumericInstruction
{
}

internal abstract class NumericBinaryOperator : NumericOperator
{
}

internal abstract class IntBinaryOperator : NumericBinaryOperator
{
}

internal class Add<T> : IntBinaryOperator
    where T : IntegerNumberType
{
}