using System.Collections.Generic;
using System.IO;
using Wasrou.Structure;

namespace Wasrou.Binary;

internal enum Prefix
{
    GC_or_String = 0xFB,
    FC = 0xFC,
    SIMD = 0xFD,
    Thread = 0xFE,
}

internal enum NormalOpCode
{
    End = 0x0B,
    LocalGet = 0x20,
    LocalSet = 0x21,
    I32Const = 0x41,
    I32Add = 0x6A,
}

internal class CodeSection
{
    public List<FunctionBody> FunctionBodies { get; } = new();

    public CodeSection(BinaryReader br)
    {
        var n = br.ReadLEB128Uint32();
        for (var i = 0; i < n; i++)
        {
            FunctionBodies.Add(ReadFunctionBody(br));
        }
    }

    private static FunctionBody ReadFunctionBody(BinaryReader br)
    {
        _ = br.ReadLEB128Uint32(); // funcbodysize
        var localDeclCount = (int)br.ReadLEB128Uint32();
        var locals = new List<ValueType>(localDeclCount);
        for (var i = 0; i < localDeclCount; i++)
        {
            var typeCount = br.ReadLEB128Uint32();
            var valueType = Common.GetValueType(br);
            for (var j = 0; j < typeCount; j++)
            {
                locals.Add(valueType);
            }
        }
        var instructions = new List<Instruction>();
        while (true)
        {
            var instruction = ReadInstruction(br);
            instructions.Add(instruction);
            if (instruction is End) break;
        }
        return new FunctionBody(locals, instructions);
    }

    private static Instruction ReadInstruction(BinaryReader br)
    {
        // プリフィックスかオペコードが来る
        var code = br.ReadByte();
        return (Prefix)code switch
        {
            Prefix.GC_or_String => throw new System.NotSupportedException(),
            Prefix.FC => throw new System.NotSupportedException(),
            Prefix.SIMD => throw new System.NotSupportedException(),
            Prefix.Thread => throw new System.NotSupportedException(),
            _ => GetNormalInstruction(br, code),
        };
    }

    private static Instruction GetNormalInstruction(BinaryReader br, byte code)
    {
        return (NormalOpCode)code switch
        {
            NormalOpCode.End => new End(),
            NormalOpCode.LocalGet => new LocalGet(new(br.ReadLEB128Uint32())),
            NormalOpCode.LocalSet => new LocalSet(new(br.ReadLEB128Uint32())),
            NormalOpCode.I32Const => new I32Const(br.ReadLEB128Int32()),
            NormalOpCode.I32Add => new Add<I32>(),
            _ => throw new WasmException(Error.オペコードが不正です),
        };
    }
}

internal class FunctionBody
{
    public List<ValueType> Locals { get; }
    public List<Instruction> Instructions { get; }

    public FunctionBody(List<ValueType> locals, List<Instruction> instructions)
    {
        Locals = locals;
        Instructions = instructions;
    }
}