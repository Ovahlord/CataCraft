using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GlueScreenEmote.dbc")]
public sealed class GlueScreenEmoteEntry
{
    [Index(false)]
    public uint ID;
    public int ClassID;
    public int RaceID;
    public int SexID;
    public int LeftHandItemType;
    public int RightHandItemType;
    public int AnimKitID;
    public int SpellVisualKitID;
}
