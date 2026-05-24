using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CharHairGeosets.dbc")]
public sealed class CharHairGeosetsEntry
{
    [Index(false)]
    public uint ID;
    public int RaceID;
    public int SexID;
    public int VariationID;
    public int GeosetID;
    public int Showscalp;
}
