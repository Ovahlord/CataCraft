using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureDisplayInfoExtra.dbc")]
public sealed class CreatureDisplayInfoExtraEntry
{
    [Index(false)]
    public uint ID;
    public int DisplayRaceID;
    public int DisplaySexID;
    public int SkinID;
    public int FaceID;
    public int HairStyleID;
    public int HairColorID;
    public int FacialHairID;
    [Cardinality(11)]
    public int[] NPCItemDisplay = new int[11];
    public int Flags;
    public string BakeName = string.Empty;
}
