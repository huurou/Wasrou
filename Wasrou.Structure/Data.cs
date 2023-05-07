using System.Collections.Generic;
using System.Linq;

namespace Wasrou.Structure;

public class Data
{
    public List<byte> Init { get; init; }
    public DataMode Mode { get; init; }

    public Data(IEnumerable<byte> init, DataMode mode)
    {
        Init = init.ToList();
        Mode = mode;
    }
}

public abstract class DataMode
{
}

public class DataModePassive : DataMode
{
}

public class DataModeActive : DataMode
{
    public MemoryIndex Memory { get; init; }
    public Expression Offset { get; init; }

    public DataModeActive(MemoryIndex memory, Expression offset)
    {
        Memory = memory;
        Offset = offset;
    }
}