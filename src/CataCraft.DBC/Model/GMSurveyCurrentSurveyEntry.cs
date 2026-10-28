using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMSurveyCurrentSurvey.dbc")]
public sealed class GMSurveyCurrentSurveyEntry
{
    [Index(true)]
    public uint LANGID;
    public int GMSURVEYID;
}
