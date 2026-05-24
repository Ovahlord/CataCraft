using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GameTables.dbc")]
public sealed class GameTablesEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int NumRows;
    public int NumColumns;
}
