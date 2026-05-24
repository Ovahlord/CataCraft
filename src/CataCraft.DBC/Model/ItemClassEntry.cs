using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemClass.dbc")]
public sealed class ItemClassEntry
{
    [Index(false)]
    public uint ID;
    public int ClassID;
    public int SubclassMapID;
    public int Flags;
    public float PriceModifier;
    public string ClassName = string.Empty;
}
