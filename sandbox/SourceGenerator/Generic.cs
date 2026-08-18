using MemoryPack;

namespace Case3;

// MemoryPackFormatter.g.cs に外側型の型引数が出力されない（partial class GenericOuter になってしまう）。
// アリティ 0 の別の型なので、生成コードは Inner とは別のデコイ型を宣言することになり、
// CS1061 / CS0117（'GenericOuter.Inner' に 'X' の定義がない）になる。
// GetContainingTypeDeclarations() が containingType.Name を使っており、型引数を落としているため。
public partial class GenericOuter<T>
{
    [MemoryPackable]
    public partial class Inner
    {
        public int X { get; set; }
    }
}

// union パスでも同じ。メンバー型を外側型の外に出せば、属性引数の CS0416 を回避して到達できる。
// CS0246（型 'T' が見つからない）/ CS7003（バインドされていないジェネリック名）のほか、
// GenericUnionOuter.IUnion と GenericUnionOuter<T>.IUnion が並ぶ CS1503 になる。
public partial class GenericUnionOuter<T>
{
    [MemoryPackable]
    [MemoryPackUnion(0, typeof(GenericImpl<>))]
    public partial interface IUnion
    {
    }
}

[MemoryPackable]
public partial class GenericImpl<T> : GenericUnionOuter<T>.IUnion
{
    public int X { get; set; }
}
