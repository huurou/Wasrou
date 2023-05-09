using System;
using System.Runtime.Serialization;

namespace Wasrou;

public enum Error
{
    最外部リストの外に要素があります,
    余計な左括弧があります,
    余計な右括弧があります,
    リストがありません,

    バイナリが途中で終わっています,
    マジックナンバーが不正です,
    バージョンが不正です,
    セクションの順番が不正です,
    セクションIdが不正です,
    TypeSectionのタイプコードが不正です,
    タイプコードが不正です,
    ExportKindが不正です,
    オペコードが不正です,

    ローカルリストの範囲外です,
    ローカルの型が異なります,
    スタックが空です,
    ストックトップが値じゃないです,
    スタックトップと要求値タイプが異なります,
    スタックが空あるいは値以外の要素がありません,
    スタックの要素数が足りません,
    要求された個数分の値がスタックトップから連続して存在しません,
    スタックトップにフレームがありません,
    スタックにフレームがありません,
    スタックトップにラベルがありません,
    スタックトップのラベルが不正です,
    スタックトップのフレームが不正です,
    関数アドレスリストの範囲外です,
    アドレスが関数インスタンスリストの範囲外です,
}

[Serializable]
internal class WasmException : Exception
{
    public Error Error { get; }

    public WasmException(Error error, Exception? innerException = null)
        : base(error.ToString(), innerException)
    {
        Error = error;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
}