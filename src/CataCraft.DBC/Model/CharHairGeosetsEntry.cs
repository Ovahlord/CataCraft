using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CharHairGeosets.dbc")]
public sealed class CharHairGeosetsEntry
{
    [Index(true)]
    public uint ID;
    public int RaceID;
    public int SexID;
    public int VariationID;
    public int GeosetID;
    public int Showscalp;
}
