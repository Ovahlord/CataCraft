using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMSurveyQuestions.dbc")]
public sealed class GMSurveyQuestionsEntry
{
    [Index(true)]
    public uint ID;
    public string Question = string.Empty;
}
