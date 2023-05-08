namespace Wasrou.Structure;

internal class Memory
{
    internal MemoryType Type { get; }

    internal Memory(MemoryType type)
    {
        Type = type;
    }
}