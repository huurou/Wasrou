using System.Collections.Generic;
using System.IO;
using Wasrou.Structure;

namespace Wasrou.Binary;

internal class Module
{
    public const uint WASM_MAGIC_NUMBER = 0x6d736100;
    public const uint WASM_VERSION = 0x1;

    public List<CustomSection> CustomSections { get; } = new();
    public TypeSection? TypeSection { get; }
    public List<Import>? ImportSection { get; }
    public FunctionSection? FunctionSection { get; }
    public List<TableType>? TableSection { get; }
    public List<MemoryType>? MemorySection { get; }
    public List<Global>? GlobalSection { get; }
    public ExportSection? ExportSection { get; }
    public FunctionIndex? StartSection { get; }
    public List<Element>? ElementSection { get; }
    public uint? DataCountSection { get; }
    public CodeSection? CodeSection { get; }
    public DataSection? DataSection { get; }

    public Module(BinaryReader br)
    {
        if (br.ReadUInt32() != WASM_MAGIC_NUMBER) throw new WasmException(Error.マジックナンバーが不正です);
        if (br.ReadUInt32() != WASM_VERSION) throw new WasmException(Error.バージョンが不正です);
        var lastSectionId = SectionId.Custom;
        while (br.BaseStream.Position < br.BaseStream.Length)
        {
            var sectionId = (SectionId)br.ReadByte();
            if (sectionId != SectionId.Custom)
            {
                lastSectionId = sectionId <= lastSectionId
                    ? throw new WasmException(Error.セクションの順番が不正です)
                    : sectionId;
            }
            var size = br.ReadLEB128Uint32();
            switch (sectionId)
            {
                case SectionId.Custom:
                    CustomSections.Add(new(br, size));
                    break;

                case SectionId.Type:
                    TypeSection = new(br);
                    break;

                case SectionId.Import:
                    break;

                case SectionId.Function:
                    FunctionSection = new(br);
                    break;

                case SectionId.Table:
                    break;

                case SectionId.Memory:
                    break;

                case SectionId.Global:
                    break;

                case SectionId.Export:
                    ExportSection = new(br);
                    break;

                case SectionId.Start:
                    break;

                case SectionId.Elem:
                    break;

                case SectionId.Code:
                    CodeSection = new(br);
                    break;

                case SectionId.Data:
                    break;

                case SectionId.DataCount:
                    break;

                case SectionId.Tag:
                    break;

                default: throw new WasmException(Error.セクションIdが不正です);
            }
        }
    }
}