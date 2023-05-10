using System.IO;
using Wasrou.Binary;
using Wasrou.Structure;
using ExportDescFunction = Wasrou.Binary.ExportDescFunction;

namespace Wasrou.Test.Binary;

public class DecodeTest
{
    [Test]
    public void MinimalBinaryTest()
    {
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x01, 0x00, 0x00, 0x00,
        });
        Assert.That(() => BinaryDecoder.Decode(ms), Throws.Nothing);
    }

    [Test]
    public void MinimalBinaryWithCustomTest()
    {
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x01, 0x00, 0x00, 0x00,
            0x00, 0x08, 0x04, 0x6E, 0x61, 0x6D, 0x65, 0x02,
            0x01, 0x00,
        });
        var module = BinaryDecoder.Decode(ms);
        Assert.That(module.CustomSections, Has.Count.EqualTo(1));
        Assert.That(module.CustomSections[0].Name, Is.EqualTo("name"));
        Assert.That(module.CustomSections[0].Data, Has.Length.EqualTo(3));
    }

    [Test]
    public void TypeSectionTest()
    {
        /*
(module
  (type (func (param i32 f32) (result i64 f64)))
  (type (func (param i32)))
  (type (func (result i32))))
        */
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x01, 0x00, 0x00, 0x00,
            0x01, 0x10, 0x03, 0x60, 0x02, 0x7F, 0x7D, 0x02,
            0x7E, 0x7C, 0x60, 0x01, 0x7F, 0x00, 0x60, 0x00,
            0x01, 0x7F, 0x00, 0x08, 0x04, 0x6E, 0x61, 0x6D,
            0x65, 0x02, 0x01, 0x00,
        });
        var module = BinaryDecoder.Decode(ms);
        Assert.That(module.TypeSection, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(module.TypeSection.FunctionTypes, Has.Count.EqualTo(3));
            Assert.That(module.TypeSection.FunctionTypes[0].Parameters, Is.EquivalentTo(new NumberType[] { new I32(), new F32() }));
            Assert.That(module.TypeSection.FunctionTypes[0].Results, Is.EquivalentTo(new NumberType[] { new I64(), new F64() }));
            Assert.That(module.TypeSection.FunctionTypes[1].Parameters, Is.EquivalentTo(new[] { new I32() }));
            Assert.That(module.TypeSection.FunctionTypes[1].Results, Is.Empty);
            Assert.That(module.TypeSection.FunctionTypes[2].Parameters, Is.Empty);
            Assert.That(module.TypeSection.FunctionTypes[2].Results, Is.EquivalentTo(new[] { new I32() }));
        });
    }

    [Test]
    public void FunctionSectionTest()
    {
        /*
(module
  (func (param i32 i32) (result i32) (local i32)
    local.get 0
    local.get 1
    i32.add)
  (func (result i32 i32) (local i32 i32)
    local.get 0
    local.get 1
    i32.add
    i32.const 0))
        */
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x01, 0x00, 0x00, 0x00,
            0x01, 0x0C, 0x02, 0x60, 0x02, 0x7F, 0x7F, 0x01,
            0x7F, 0x60, 0x00, 0x02, 0x7F, 0x7F, 0x03, 0x03,
            0x02, 0x00, 0x01, 0x0A, 0x17, 0x02, 0x09, 0x01,
            0x01, 0x7F, 0x20, 0x00, 0x20, 0x01, 0x6A, 0x0B,
            0x0B, 0x01, 0x02, 0x7F, 0x20, 0x00, 0x20, 0x01,
            0x6A, 0x41, 0x00, 0x0B, 0x00, 0x0C, 0x04, 0x6E,
            0x61, 0x6D, 0x65, 0x02, 0x05, 0x02, 0x00, 0x00,
            0x01, 0x00,
        });
        var module = BinaryDecoder.Decode(ms);
        Assert.That(module.FunctionSection, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(module.FunctionSection.TypeIndices, Has.Count.EqualTo(2));
            Assert.That(module.FunctionSection.TypeIndices[0], Is.EqualTo(new TypeIndex(0)));
            Assert.That(module.FunctionSection.TypeIndices[1], Is.EqualTo(new TypeIndex(1)));
        });
    }

    [Test]
    public void ExportSectionTest()
    {
        /*
(module
  (func (export "addTwo") (param i32 i32) (result i32)
    local.get 0
    local.get 1
    i32.add))
         */
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x01, 0x00, 0x00, 0x00,
            0x01, 0x07, 0x01, 0x60, 0x02, 0x7F, 0x7F, 0x01,
            0x7F, 0x03, 0x02, 0x01, 0x00, 0x07, 0x0A, 0x01,
            0x06, 0x61, 0x64, 0x64, 0x54, 0x77, 0x6F, 0x00,
            0x00, 0x0A, 0x09, 0x01, 0x07, 0x00, 0x20, 0x00,
            0x20, 0x01, 0x6A, 0x0B, 0x00, 0x0A, 0x04, 0x6E,
            0x61, 0x6D, 0x65, 0x02, 0x03, 0x01, 0x00, 0x00,
        });
        var module = BinaryDecoder.Decode(ms);
        Assert.That(module.ExportSection, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(module.ExportSection.Exports, Has.Count.EqualTo(1));
            Assert.That(module.ExportSection.Exports[0].Name, Is.EqualTo("addTwo"));
            Assert.That(module.ExportSection.Exports[0].Desc, Is.TypeOf<ExportDescFunction>());
            Assert.That((module.ExportSection.Exports[0].Desc as ExportDescFunction)?.Index, Is.EqualTo(new FunctionIndex(0)));
        });
    }

    [Test]
    public void CodeSectionTest()
    {
        /*
(module
  (func (export "addTwo") (param i32 i32) (result i32)
    (local i32 i32 i64 i32)
    local.get 0
    local.get 1
    i32.add))
         */
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x01, 0x00, 0x00, 0x00,
            0x01, 0x07, 0x01, 0x60, 0x02, 0x7F, 0x7F, 0x01,
            0x7F, 0x03, 0x02, 0x01, 0x00, 0x07, 0x0A, 0x01,
            0x06, 0x61, 0x64, 0x64, 0x54, 0x77, 0x6F, 0x00,
            0x00, 0x0A, 0x0F, 0x01, 0x0D, 0x03, 0x02, 0x7F,
            0x01, 0x7E, 0x01, 0x7F, 0x20, 0x00, 0x20, 0x01,
            0x6A, 0x0B, 0x00, 0x0A, 0x04, 0x6E, 0x61, 0x6D,
            0x65, 0x02, 0x03, 0x01, 0x00, 0x00,
        });
        var module = BinaryDecoder.Decode(ms);
        Assert.That(module.CodeSection, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(module.CodeSection.FunctionBodies, Has.Count.EqualTo(1));
            Assert.That(module.CodeSection.FunctionBodies[0].Locals, Is.EquivalentTo(new NumberType[] { new I32(), new I32(), new I64(), new I32() }));
            Assert.That(module.CodeSection.FunctionBodies[0].Instructions[0], Is.EqualTo(new LocalGet(new(0))));
            Assert.That(module.CodeSection.FunctionBodies[0].Instructions[1], Is.EqualTo(new LocalGet(new(1))));
            Assert.That(module.CodeSection.FunctionBodies[0].Instructions[2], Is.EqualTo(new Add<I32>()));
            Assert.That(module.CodeSection.FunctionBodies[0].Instructions[3], Is.EqualTo(new End()));
        });
    }

    [Test]
    public void ShortBinaryTest()
    {
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x01, 0x00, 0x00,
        });
        Assert.That(
            () => BinaryDecoder.Decode(ms),
            Throws.TypeOf<WasmException>().With.Message.EqualTo(Error.バイナリが途中で終わっています.ToString()));
    }

    [Test]
    public void InvalidMagicNumberTest()
    {
        var ms = new MemoryStream(new byte[]
        {
            0x6D, 0x73, 0x61, 0x00, 0x01, 0x00, 0x00, 0x00,
        });
        Assert.That(
            () => BinaryDecoder.Decode(ms),
            Throws.TypeOf<WasmException>().With.Message.EqualTo(Error.マジックナンバーが不正です.ToString()));
    }

    [Test]
    public void InvalidVersionNumberTest()
    {
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x00, 0x00, 0x00, 0x01,
        });
        Assert.That(
            () => BinaryDecoder.Decode(ms),
            Throws.TypeOf<WasmException>().With.Message.EqualTo(Error.バージョンが不正です.ToString()));
    }

    [Test]
    public void InvalidSectionIdTest()
    {
        var ms = new MemoryStream(new byte[]
        {
            0x00, 0x61, 0x73, 0x6D, 0x01, 0x00, 0x00, 0x00,
            0xFF, 0x08, 0x04, 0x6E, 0x61, 0x6D, 0x65, 0x02,
            0x01, 0x00,
        });
        Assert.That(
            () => BinaryDecoder.Decode(ms),
            Throws.TypeOf<WasmException>().With.Message.EqualTo(Error.セクションIdが不正です.ToString()));
    }
}