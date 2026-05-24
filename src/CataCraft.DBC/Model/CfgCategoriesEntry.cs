using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Cfg_Categories.dbc")]
public sealed class CfgCategoriesEntry
{
    [Index(false)]
    public uint ID;
    public int LocaleMask;
    public int CreateCharsetMask;
    public int ExistingCharsetMask;
    public int Flags;
    public string Name = string.Empty;
}
