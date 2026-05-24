using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WeaponSwingSounds2.dbc")]
public sealed class WeaponSwingSounds2Entry
{
    [Index(false)]
    public uint ID;
    public int SwingType;
    public int Crit;
    public int SoundID;
}
