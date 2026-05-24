using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("EnvironmentalDamage.dbc")]
public sealed class EnvironmentalDamageEntry
{
    [Index(false)]
    public uint ID;
    public int EnumID;
    public int VisualkitID;
}
