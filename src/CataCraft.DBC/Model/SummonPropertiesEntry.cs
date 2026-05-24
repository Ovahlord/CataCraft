using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SummonProperties.dbc")]
public sealed class SummonPropertiesEntry
{
    [Index(false)]
    public uint ID;
    public int Control;
    public int Faction;
    public int Title;
    public int Slot;
    public int Flags;
}
