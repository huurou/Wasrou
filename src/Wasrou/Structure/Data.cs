using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

internal class Data
{
    public List<byte> Init { get; }
    public DataMode Mode { get; }

    public Data(IEnumerable<byte> init, DataMode mode)
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
    public MemoryIndex Memory { get; }
    public Expression Offset { get; }

    public DataModeActive(MemoryIndex memory, Expression offset)
    {
        Memory = memory;
        Offset = offset;
    }
}