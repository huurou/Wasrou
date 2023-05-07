namespace Wasrou.Structure;

public class Memory
{
    public MemoryType Type { get; init; }

    public Memory(MemoryType type)
    {
        Type = type;
    }
}