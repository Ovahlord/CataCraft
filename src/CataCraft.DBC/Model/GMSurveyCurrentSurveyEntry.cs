using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMSurveyCurrentSurvey.dbc")]
public sealed class GMSurveyCurrentSurveyEntry
{
    [Index(false)]
    public uint LANGID;
    public int GMSURVEYID;
}
