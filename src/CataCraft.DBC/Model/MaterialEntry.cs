using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Material.dbc")]
public sealed class MaterialEntry
{
    [Index(true)]
    public uint ID;
    public int Flags;
    public int FoleySoundID;
    public int SheatheSoundID;
    public int UnsheatheSoundID;
}
