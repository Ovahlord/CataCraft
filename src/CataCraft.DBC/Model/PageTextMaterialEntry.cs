using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PageTextMaterial.dbc")]
public sealed class PageTextMaterialEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
