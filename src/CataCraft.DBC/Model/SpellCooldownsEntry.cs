using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellCooldowns.dbc")]
public sealed class SpellCooldownsEntry
{
    [Index(true)]
    public uint ID;
    public int CategoryRecoveryTime;
    public int RecoveryTime;
    public int StartRecoveryTime;
}
