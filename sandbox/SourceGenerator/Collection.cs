using System.Collections.Generic;

using MemoryPack;

namespace Case1;

// MemoryPackFormatter.g.cs に Holder が出力されない（Case1.NestedList になってしまう）
// PR #386 で直る
public partial class Holder
{
    [MemoryPackable(GenerateType.Collection)]
    public partial class NestedList : List<int>
    {
    }
}

[MemoryPackable(GenerateType.Collection)]
public partial class MyList : List<int>
{
}
