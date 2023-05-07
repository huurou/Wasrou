using System.Collections.Generic;

namespace Wasrou.Structure;

internal class Module
{
    internal List<FunctionType> Types { get; init; } = new();
    internal List<Function> Functions { get; init; } = new();
    internal List<Table> Tables { get; init; } = new();
    internal List<Memory> Memories { get; init; } = new();
    internal List<Global> Globals { get; init; } = new();
    internal List<Element> Elements { get; init; } = new();
    internal List<Data> Datas { get; init; } = new();
    internal Start? Start { get; init; }
    internal List<Import> Imports { get; init; } = new();
    internal List<Export> Exports { get; init; } = new();
}