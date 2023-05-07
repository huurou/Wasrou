using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Expression
{
    // instr*部分だけ
    internal List<Instruction> Instrs { get; }
    // instr* end
    internal List<Instruction> Value { get; }

    internal Expression(IEnumerable<Instruction>? instrs = null)
    {
        Instrs = instrs?.ToList() ?? new();
        Value = Instrs.Append(new End()).ToList();
    }
}