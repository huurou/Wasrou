namespace Wasrou.Structure;

internal class Memory
{
    internal MemoryType Type { get; init; }

    internal Memory(MemoryType type)
    {
        Type = type;
    }
}