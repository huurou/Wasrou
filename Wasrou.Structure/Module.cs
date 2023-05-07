using System.Collections.Generic;

namespace Wasrou.Structure;

public class Module
{
    public List<FunctionType> Types { get; init; } = new();
    public List<Function> Functions { get; init; } = new();
    public List<Table> Tables { get; init; } = new();
    public List<Memory> Memories { get; init; } = new();
    public List<Global> Globals { get; init; } = new();
    public List<Element> Elements { get; init; } = new();
    public List<Data> Datas { get; init; } = new();
    public Start? Start { get; init; }
    public List<Import> Imports { get; init; } = new();
    public List<Export> Exports { get; init; } = new();
}