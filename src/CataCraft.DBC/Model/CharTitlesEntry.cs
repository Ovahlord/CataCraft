using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CharTitles.dbc")]
public sealed class CharTitlesEntry
{
    [Index(false)]
    public uint ID;
    public int ConditionID;
    public string Name = string.Empty;
    public string Name1 = string.Empty;
    public int MaskID;
    public int Flags;
}
