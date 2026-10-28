using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("EnvironmentalDamage.dbc")]
public sealed class EnvironmentalDamageEntry
{
    [Index(true)]
    public uint ID;
    public int EnumID;
    public int VisualkitID;
}
