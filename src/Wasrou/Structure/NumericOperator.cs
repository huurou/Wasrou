namespace Wasrou.Structure;

internal abstract record NumericOperator : NumericInstruction;

internal abstract record NumericBinaryOperator : NumericOperator;

internal abstract record IntBinaryOperator : NumericBinaryOperator;

internal record Add<T> : IntBinaryOperator 
    where T : IntegerNumberType;