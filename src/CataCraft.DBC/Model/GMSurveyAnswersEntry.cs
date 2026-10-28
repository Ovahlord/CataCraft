using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMSurveyAnswers.dbc")]
public sealed class GMSurveyAnswersEntry
{
    [Index(true)]
    public uint ID;
    public int SortIndex;
    public int GMSurveyQuestionID;
    public string Answer = string.Empty;
}
