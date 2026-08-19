using MemoryPack;

namespace Case2;

// 生成コードは別ファイルとして出力されるため、file ローカル型と partial として結合できず、
// 中身が空の別の型に対してシリアライズ コードが生成される。
//   error CS1061: 'FileTarget' に 'X' の定義が含まれておらず…
//   error CS0117: 'FileTarget' に 'X' の定義がありません
// 生成をスキップするか、診断を報告して弾くべき。
[MemoryPackable]
file partial class FileTarget
{
    public int X { get; set; }
}
