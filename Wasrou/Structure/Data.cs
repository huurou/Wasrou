using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Data
{
    internal List<byte> Init { get; init; }
    internal DataMode Mode { get; init; }

    internal Data(IEnumerable<byte> init, DataMode mode)
    {
        Init = init.ToList();
        Mode = mode;
    }
}

internal abstract class DataMode
{
}

internal class DataModePassive : DataMode
{
}

internal class DataModeActive : DataMode
{
    internal MemoryIndex Memory { get; init; }
    internal Expression Offset { get; init; }

    internal DataModeActive(MemoryIndex memory, Expression offset)
    {
        Memory = memory;
        Offset = offset;
    }
}