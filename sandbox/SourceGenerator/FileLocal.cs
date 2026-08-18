using MemoryPack;

namespace Case4;

// file ローカル型を外側型としてネストすると、生成コードが別の型になってしまう（Source Generator では file partial に対してコードを足せない）。
// このケースは無視するか警告を出すべき。
file partial class FileHolder
{
    [MemoryPackable]
    [MemoryPackUnion(0, typeof(A))]
    public partial interface IU
    {
    }

    [MemoryPackable]
    public partial record A(int X) : IU;
}
