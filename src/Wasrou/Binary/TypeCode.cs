namespace Wasrou.Binary;

internal enum TypeCode
{
    I32 = 0x7F,
    I64 = 0x7E,
    F32 = 0x7D,
    F64 = 0x7C,
    V128 = 0x7B,
    I8 = 0x7A,
    I16 = 0x79,
    FuncRef = 0x70,
    ExternRef = 0x6F,
    Function = 0x60,
}