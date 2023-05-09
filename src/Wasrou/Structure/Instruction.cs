namespace Wasrou.Structure;

internal abstract class Instruction
{
}

internal abstract class NumericInstruction : Instruction
{
}

internal class I32Const : NumericInstruction
{
    public int Value { get; }

    public I32Const(int value)
    {
        Value = value;
    }
}


internal abstract class VariableInstruction : Instruction
{
}

internal class End : Instruction
{
}

internal class LocalGet : VariableInstruction
{
    public LocalIndex LocalIndex { get; }

    public LocalGet(LocalIndex localIndex)
    {
        LocalIndex = localIndex;
    }
}

internal class LocalSet : VariableInstruction
{
    public LocalIndex LocalIndex { get; }

    public LocalSet(LocalIndex localIndex)
    {
        LocalIndex = localIndex;
    }
}
