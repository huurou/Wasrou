using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Expression
{
    // instr*部分だけ
    public List<Instruction> Instrs { get; }
    // instr* end
    public List<Instruction> Value { get; }

    public Expression(IEnumerable<Instruction>? instrs = null)
    {
        Instrs = instrs?.ToList() ?? new();
        Value = Instrs.Append(new End()).ToList();
    }
}