namespace Wasrou.Structure;

internal abstract record Instruction;

internal abstract record NumericInstruction : Instruction;

internal record I32Const(int Value) : NumericInstruction;

internal abstract record VariableInstruction : Instruction;

internal record End : Instruction;

internal record LocalGet(LocalIndex Index) : VariableInstruction;

internal record LocalSet(LocalIndex Index) : VariableInstruction;