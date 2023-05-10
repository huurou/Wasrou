namespace Wasrou.Structure;

internal abstract record ValueType;

internal abstract record NumberType : ValueType;

internal abstract record IntegerNumberType : NumberType;

internal record I32 : IntegerNumberType;

internal record I64 : IntegerNumberType;

internal abstract record FloatNumberType : NumberType;

internal record F32 : FloatNumberType;

internal record F64 : FloatNumberType;

internal abstract record VectorType : ValueType;

internal record V128 : VectorType;

internal abstract record ReferenceType : ValueType;

internal record FunctionReference : ReferenceType;

internal record ExternalReference : ReferenceType;