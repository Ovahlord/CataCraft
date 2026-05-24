using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMSurveySurveys.dbc")]
public sealed class GMSurveySurveysEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(15)]
    public int[] Q = new int[15];
}
