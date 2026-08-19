using MemoryPack;

namespace Case1;

// abstract record を外側型にすると、生成コードの外側型宣言が partial class になり CS0261 になる。
//   error CS0261: 'AbstractRecordHolder' の部分宣言は、すべてのクラス、…である必要があります
//
// PR #386 の containingTypeDeclarations の switch は
// (IsRecord, IsValueType, IsAbstract, isInterface) の組み合わせのうち
// (true, false, true, false) = abstract record class を列挙しておらず、
// 捨て節 `_ => partial class` に落ちてしまう。
public abstract partial record AbstractRecordHolder
{
    [MemoryPackable]
    public partial class Inner
    {
        public int X { get; set; }
    }
}

// 同じ理由で、abstract record を外側型に持つ union・collection も壊れる。
public abstract partial record AbstractRecordUnionHolder
{
    [MemoryPackable]
    [MemoryPackUnion(0, typeof(Impl))]
    public partial interface IUnion
    {
    }

    [MemoryPackable]
    public partial class Impl : IUnion
    {
        public int X { get; set; }
    }
}
