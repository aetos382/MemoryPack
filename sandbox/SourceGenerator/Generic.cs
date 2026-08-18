using MemoryPack;

namespace Case3;

// MemoryPackFormatter.g.cs に外側型の型引数が出力されない（partial class GenericOuter になってしまう）。
// GetContainingTypeDeclarations() が containingType.Name を使っており、型引数を落としているため。
public partial class GenericOuter<T>
{
    [MemoryPackable]
    public partial class Inner
    {
        public int X { get; set; }
    }
}

// union パスでも同じ。
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
