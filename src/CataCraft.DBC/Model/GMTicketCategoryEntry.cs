using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GMTicketCategory.dbc")]
public sealed class GMTicketCategoryEntry
{
    [Index(false)]
    public uint ID;
    public string Category = string.Empty;
}
