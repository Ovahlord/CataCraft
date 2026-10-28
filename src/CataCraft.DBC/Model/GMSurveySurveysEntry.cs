using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMSurveySurveys.dbc")]
public sealed class GMSurveySurveysEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(15)]
    public int[] Q = new int[15];
}
