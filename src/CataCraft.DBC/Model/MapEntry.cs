using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Map.dbc")]
public sealed class MapEntry
{
    [Index(false)]
    public uint ID;
    public string Directory = string.Empty;
    public int InstanceType;
    public int Flags;
    public int MapType;
    public int PVP;
    public string MapName = string.Empty;
    public int AreaTableID;
    public string MapDescription0 = string.Empty;
    public string MapDescription1 = string.Empty;
    public int LoadingScreenID;
    public float MinimapIconScale;
    public int CorpseMapID;
    [Cardinality(2)]
    public float[] Corpse = new float[2];
    public int TimeOfDayOverride;
    public int ExpansionID;
    public int RaidOffset;
    public int MaxPlayers;
    public int ParentMapID;
}
