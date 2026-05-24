using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemSubClass.dbc")]
public sealed class ItemSubClassEntry
{
    [Index(false)]
    public uint ID;
    public int ClassID;
    public int SubClassID;
    public int PrerequisiteProficiency;
    public int PostrequisiteProficiency;
    public int Flags;
    public int DisplayFlags;
    public int WeaponParrySeq;
    public int WeaponReadySeq;
    public int WeaponAttackSeq;
    public int WeaponSwingSize;
    public string DisplayName = string.Empty;
    public string VerboseName = string.Empty;
}
