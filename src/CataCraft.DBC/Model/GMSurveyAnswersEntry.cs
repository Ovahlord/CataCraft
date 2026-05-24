using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMSurveyAnswers.dbc")]
public sealed class GMSurveyAnswersEntry
{
    [Index(false)]
    public uint ID;
    public int SortIndex;
    public int GMSurveyQuestionID;
    public string Answer = string.Empty;
}
