using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaTrigger.dbc")]
public sealed class AreaTriggerEntry
{
    [Index(false)]
    public uint ID;
    public int ContinentID;
    [Cardinality(3)]
    public float[] Pos = new float[3];
    public int PhaseUseFlags;
    public int PhaseID;
    public int PhaseGroupID;
    public float Radius;
    public float BoxLength;
    public float BoxWidth;
    public float BoxHeight;
    public float BoxYaw;
}
