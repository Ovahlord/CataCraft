using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Material.dbc")]
public sealed class MaterialEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public int FoleySoundID;
    public int SheatheSoundID;
    public int UnsheatheSoundID;
}
