using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMSurveyQuestions.dbc")]
public sealed class GMSurveyQuestionsEntry
{
    [Index(false)]
    public uint ID;
    public string Question = string.Empty;
}
