using MemoryPack;

namespace Case2;

public interface IExternalUnion;

[MemoryPackable]
public partial class ExternalImpl : IExternalUnion
{
    public int X { get; set; }
}

// MemoryPackFormatter.g.cs に Holder が出力されない（Case2.ExternalUnionFormatter になってしまう）。
// そのため、この Formatter は使われない。
public partial class Holder
{
    [MemoryPackUnionFormatter(typeof(IExternalUnion))]
    [MemoryPackUnion(0, typeof(ExternalImpl))]
    public partial class ExternalUnionFormatter
    {
    }
}
